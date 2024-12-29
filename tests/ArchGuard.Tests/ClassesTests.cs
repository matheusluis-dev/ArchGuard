namespace ArchGuard.Tests;

public sealed class ClassesTests
{
    [Fact]
    public void Get_classes()
    {
        // Arrange
        var filters = TypesFromMockedAssembly.All.That().AreClasses();

        // Act
        var types = filters.GetTypes().GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(TypeNames.Classes);
    }

    [Fact]
    public void Get_non_class_types()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;
        var nonClassTypes = TypeNames.Types.Except(TypeNames.Classes, StringComparer.Ordinal);

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .AreNotClasses()
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(nonClassTypes);
    }

    [Fact]
    public void Get_public_classes()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .AreClasses()
            .And()
            .ArePublic()
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(TypeNames.ClassesPublic);
    }

    [Fact]
    public void Get_internal_classes()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .AreClasses()
            .And()
            .AreInternal()
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(TypeNames.ClassesInternal);
    }

    [Fact]
    public void Get_partial_classes()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .AreClasses()
            .And()
            .ArePartial()
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo([TypeNames.PublicPartialClass]);
    }

    [Fact]
    public void Get_sealed_classes()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;
        var sealedClasses = new List<string>
        {
            TypeNames.InternalSealedClass,
            TypeNames.PublicSealedClass,
        };

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .AreClasses()
            .And()
            .AreSealed()
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(sealedClasses);
    }
}
