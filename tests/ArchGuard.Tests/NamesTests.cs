namespace ArchGuard.Tests;

public sealed class NamesTests
{
    [Fact]
    public void Name_starting()
    {
        // Arrange
        var expected = new List<string>
        {
            TypeNames.PublicSealedClass,
            TypeNames.PublicSealedRecord,
        };
        var filters = TypesFromMockedAssembly.All.That().HaveNameStartingWith("PublicSealed");

        // Act
        var types = filters.GetTypes().GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Name_starting_with_StringComparison()
    {
        // Arrange
        var expected = new List<string>
        {
            TypeNames.PublicSealedClass,
            TypeNames.PublicSealedRecord,
        };
        var filters = TypesFromMockedAssembly
            .All.That()
            .HaveNameStartingWith("publicsealed", StringComparison.OrdinalIgnoreCase);

        // Act
        var types = filters.GetTypes().GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Name_ending()
    {
        // Arrange
        var expected = TypeNames.Classes;
        var filters = TypesFromMockedAssembly.All.That().HaveNameEndingWith("Class");

        // Act
        var types = filters.GetTypes().GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Name_ending_with_StringComparison()
    {
        // Arrange
        var expected = TypeNames.Classes;
        var filters = TypesFromMockedAssembly
            .All.That()
            .HaveNameEndingWith("class", StringComparison.OrdinalIgnoreCase);

        // Act
        var types = filters.GetTypes().GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(expected);
    }
}
