namespace ArchGuard.Assertions.Tests.Modifiers.Access
{
    using System;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class PublicTests
    {
        [Fact]
        public void Public_types()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespaceContaining(".Public.");

            var filtersTypes = filters.GetTypes(StringComparison.Ordinal);

            // Act
            var assertion = filters.Should.BePublic().GetResult(StringComparison.Ordinal);

            // Assert
            assertion.IsSuccessful.Should().BeTrue();
            assertion.TypesFiltered.Should().BeEquivalentTo(filtersTypes);
            assertion.CompliantTypes.Should().BeEquivalentTo(filtersTypes);
            assertion.NonCompliantTypes.Should().BeEmpty();
        }

        [Fact]
        public void Public_types_non_successful()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespace(Namespaces.Interfaces);

            var filtersTypes = filters.GetTypes(StringComparison.Ordinal);

            // Act
            var assertion = filters.Should.BePublic().GetResult(StringComparison.Ordinal);

            // Assert
            assertion.IsSuccessful.Should().BeFalse();
            assertion.TypesFiltered.Should().BeEquivalentTo(filtersTypes);
            assertion
                .CompliantTypes.Should()
                .ContainSingle()
                .Which.FullName.Equals(TypeNames.IPublicInterface, StringComparison.Ordinal);
            assertion
                .NonCompliantTypes.Should()
                .ContainSingle()
                .Which.FullName.Equals(TypeNames.IInternalInterface, StringComparison.Ordinal);
        }
    }
}
