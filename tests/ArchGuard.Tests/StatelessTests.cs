namespace ArchGuard.Filters.Tests
{
    using System;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class StatelessTests
    {
        [Fact]
        public void AreStateless()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.Stateless)
                .And.AreStateless();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.Stateless.PublicStatelessClass.ToListString());
        }

        [Fact]
        public void AreNotStateless()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.Stateless)
                .And.AreNotStateless();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(TypeNames.Stateless.PublicNonStatelessClass.ToListString());
        }
    }
}
