namespace ArchGuard.Assertions.Tests.Modifiers.Access
{
    using System;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class InternalTests
    {
        [Fact]
        public void Internal_types()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespaceContaining(".Internal.");

            var filtersTypes = filters.GetTypes(StringComparison.Ordinal);

            // Act
            var assertion = filters.Should.BeInternal().GetResult(StringComparison.Ordinal);

            // Assert
            assertion.IsSuccessful.Should().BeTrue();
            assertion.TypesFiltered.Should().BeEquivalentTo(filtersTypes);
            assertion.CompliantTypes.Should().BeEquivalentTo(filtersTypes);
            assertion.NonCompliantTypes.Should().BeEmpty();
        }

        [Fact]
        public void Internal_types_non_successful()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespace(Namespaces.Interfaces);

            var filtersTypes = filters.GetTypes(StringComparison.Ordinal);

            // Act
            var assertion = filters.Should.BeInternal().GetResult(StringComparison.Ordinal);

            // Assert
            assertion.IsSuccessful.Should().BeFalse();
            assertion.TypesFiltered.Should().BeEquivalentTo(filtersTypes);
            assertion
                .CompliantTypes.GetFullNames()
                .Should()
                .BeEquivalentTo(TypeNames.IInternalInterface.ToListString());
            assertion
                .NonCompliantTypes.GetFullNames()
                .Should()
                .BeEquivalentTo(TypeNames.IPublicInterface.ToListString());
        }
    }
}
