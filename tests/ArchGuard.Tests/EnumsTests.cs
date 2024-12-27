namespace ArchGuard.Tests;

public sealed class EnumsTests
{
    [Fact]
    public void Get_enums()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;

        // Act
        var types = Types.FromAssembly(assembly).That().AreEnums().GetTypes().GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(TypeNames.Enums);
    }

    [Fact]
    public void Get_non_enum_types()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;
        var nonEnumTypes = TypeNames.Types.Except(TypeNames.Enums, StringComparer.Ordinal);

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .AreNotEnums()
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(nonEnumTypes);
    }

    [Fact]
    public void Get_public_enums()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .AreEnums()
            .And()
            .ArePublic()
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(TypeNames.EnumsPublic);
    }

    [Fact]
    public void Get_internal_enums()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .AreEnums()
            .And()
            .AreInternal()
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(TypeNames.EnumsInternal);
    }
}
