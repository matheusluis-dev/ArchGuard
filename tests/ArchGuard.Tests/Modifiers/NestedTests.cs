namespace ArchGuard.Filters.Tests.Modifiers
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
                .And.AreNested();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.Nested.PublicNestedClass,
                    TypeNames.Nested.InternalNestedClass,
                    TypeNames.Nested.ProtectedNestedClass,
                    TypeNames.Nested.PrivateNestedClass
                );
        }

        [Fact]
        public void Non_nested_types()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(Namespaces.Nested)
                .And.AreNotNested();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.Nested.PublicParentClass,
                    TypeNames.Nested.PublicNonNestedClass
                );
        }
    }
}
