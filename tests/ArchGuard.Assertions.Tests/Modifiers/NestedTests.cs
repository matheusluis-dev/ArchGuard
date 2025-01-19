namespace ArchGuard.Assertions.Tests.Modifiers
{
    using System;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class NestedTests
    {
        [Fact]
        public void Nested_types()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(Namespaces.Nested)
                .And.HaveFullNameMatching(@"\+");

            var filtersTypes = filters.GetTypes(StringComparison.Ordinal);

            // Act
            var assertion = filters.Should.BeNested().GetResult(StringComparison.Ordinal);

            // Assert
            assertion.IsSuccessful.Should().BeTrue();
            assertion.TypesFiltered.Should().BeEquivalentTo(filtersTypes);
            assertion.CompliantTypes.Should().BeEquivalentTo(filtersTypes);
            assertion.NonCompliantTypes.Should().BeEmpty();
        }

        [Fact]
        public void Nested_types_non_successful()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespace(Namespaces.Nested);

            var filtersTypes = filters.GetTypes(StringComparison.Ordinal);

            // Act
            var assertion = filters.Should.BeNested().GetResult(StringComparison.Ordinal);

            // Assert
            assertion.IsSuccessful.Should().BeFalse();
            assertion.TypesFiltered.Should().BeEquivalentTo(filtersTypes);
            assertion
                .CompliantTypes.GetFullNames()
                .Should()
                .BeEquivalentTo(
                    TypeNames.Nested.InternalNestedClass,
                    TypeNames.Nested.PrivateNestedClass,
                    TypeNames.Nested.ProtectedNestedClass,
                    TypeNames.Nested.PublicNestedClass
                );
            assertion
                .NonCompliantTypes.GetFullNames()
                .Should()
                .BeEquivalentTo(
                    TypeNames.Nested.PublicNonNestedClass,
                    TypeNames.Nested.PublicParentClass
                );
        }
    }
}
