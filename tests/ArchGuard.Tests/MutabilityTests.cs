namespace ArchGuard.Filters.Tests
{
    using System;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class MutabilityTests
    {
        [Fact]
        public void AreMutable()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.Mutability)
                .And.AreMutable();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.PublicMutableClass,
                    TypeNames.PublicMutableRecord,
                    TypeNames.PublicMutableParentClass,
                    TypeNames.PublicMutableByInheritanceClass
                );
        }

        [Fact]
        public void AreImmutable()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.Mutability)
                .And.AreImmutable();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.PublicImmutableClass,
                    TypeNames.PublicImmutableWithInitPropertyClass,
                    TypeNames.PublicImmutableWithReadOnlyFieldClass,
                    TypeNames.PublicImmutableWithConstFieldClass,
                    TypeNames.PublicImmutableRecord,
                    TypeNames.PublicImmutableParentClass,
                    TypeNames.PublicImmutableWithInheritanceClass
                );
        }
    }
}
