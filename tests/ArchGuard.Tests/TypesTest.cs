namespace ArchGuard.Tests
{
    using ArchGuard.Library.Types;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.MockedAssembly.Classes.Public;
    using FluentAssertions;
    using Xunit;

    public sealed class TypesTest
    {
        [Fact]
        public void No_duplicates()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;

            // Act
            var types = Types.FromAssembly(assembly).GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().OnlyHaveUniqueItems();
        }

        [Fact]
        public void Get_all_types()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;

            // Act
            var types = Types.FromAssembly(assembly).GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.Types);
        }
    }
}
