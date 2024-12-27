namespace ArchGuard.Tests;

public sealed class NamespacesTests
{
    [Fact]
    public void Reside_in_namespace()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .ResideInNamespace(Namespaces.ClassesPublic)
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(TypeNames.ClassesPublic);
    }

    [Fact]
    public void Reside_in_namespace_StringComparison_overload()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .ResideInNamespace(
                Namespaces.ClassesPublic.ToUpperInvariant(),
                StringComparison.OrdinalIgnoreCase
            )
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(TypeNames.ClassesPublic);
    }
}
