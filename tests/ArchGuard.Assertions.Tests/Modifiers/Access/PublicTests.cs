namespace ArchGuard.Assertions.Tests.Modifiers.Access
{
    using System;
    using ArchGuard.Tests.Common;
    using FluentAssertions;
    using Xunit;

    public sealed class PublicTests
    {
        [Fact]
        public void Public_types()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That()
                .ResideInNamespaceContaining(".Public.", StringComparison.Ordinal);

            var filtersTypes = filters.GetTypes();

            // Act
            var assertion = filters.Should.BePublic().GetResult();

            // Assert
            assertion.IsSuccessful.Should().BeTrue();
            assertion.NonCompliantTypes.Should().BeEmpty();
            assertion.TypesFiltered.Should().BeEquivalentTo(filtersTypes);
        }
    }
}
