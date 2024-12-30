namespace ArchGuard.Tests
{
    using ArchGuard.Library.Types;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types.Builder;
    using ArchGuard.Tests.MockedAssembly.Classes.Public;
    using FluentAssertions;
    using Xunit;

    public sealed class TypesTest
    {
        [Fact]
        public void Get_all_types()
        {
            // Arrange
            var expected = TypeNamesFromMockedAssembly.All().GetTypeNames();
            var filters = TypesFromMockedAssembly.All;

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }
    }
}
