namespace ArchGuard.Tests;

public sealed class LogicalOperatorsTests
{
    [Fact]
    public void And()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;
        var nonPublicClasses = new List<string>
        {
            TypeNames.InternalClass,
            TypeNames.InternalSealedClass,
            TypeNames.InternalStaticClass,
        };

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .AreClasses()
            .And()
            .AreNotPublic()
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(nonPublicClasses);
    }

    [Fact]
    public void And_and()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;
        var nonPublicAndSealedClasses = new List<string> { TypeNames.InternalSealedClass };

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .AreClasses()
            .And()
            .AreNotPublic()
            .And()
            .AreSealed()
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(nonPublicAndSealedClasses);
    }

    [Fact]
    public void Or()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;
        var recordsAndInterfaces = new List<string>();
        recordsAndInterfaces.AddRange(TypeNames.Interfaces);
        recordsAndInterfaces.AddRange(TypeNames.Records);

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .AreInterfaces()
            .Or()
            .AreRecords()
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(recordsAndInterfaces);
    }

    [Fact]
    public void And_or()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;
        var publicClassesAndInterfaces = TypeNames.ClassesPublic.Concat(TypeNames.Interfaces);

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .AreClasses()
            .And()
            .ArePublic()
            .Or()
            .AreInterfaces()
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(publicClassesAndInterfaces);
    }

    [Fact]
    public void And_or_and()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;
        var publicClassesAndInternalInterfaces = TypeNames.ClassesPublic.Concat(
            TypeNames.InterfacesInternal
        );

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .AreClasses()
            .And()
            .ArePublic()
            .Or()
            .AreInterfaces()
            .And()
            .AreInternal()
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(publicClassesAndInternalInterfaces);
    }

    [Fact]
    public void And_or_and_or()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;
        var publicClassesAndInternalInterfacesAndRecords = TypeNames
            .ClassesPublic.Concat(TypeNames.InterfacesInternal)
            .Concat(TypeNames.Records);

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .AreClasses()
            .And()
            .ArePublic()
            .Or()
            .AreInterfaces()
            .And()
            .AreInternal()
            .Or()
            .AreRecords()
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(publicClassesAndInternalInterfacesAndRecords);
    }
}
