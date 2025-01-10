namespace ArchGuard.Filters.Tests
{
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class GenericsTests
    {
        [Fact]
        public void Are_generic()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.AreGeneric();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.PublicGenericClassWithOneType,
                    TypeNames.PublicGenericClassWithTwoTypes
                );
        }
    }
}
