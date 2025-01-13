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
                    TypeNames.Mutability.PublicMutableClass,
                    TypeNames.Mutability.PublicMutableRecord,
                    TypeNames.Mutability.PublicMutableParentClass,
                    TypeNames.Mutability.PublicMutableByInheritanceClass
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
                    TypeNames.Mutability.PublicImmutableClass,
                    TypeNames.Mutability.PublicImmutableWithInitPropertyClass,
                    TypeNames.Mutability.PublicImmutableWithReadOnlyFieldClass,
                    TypeNames.Mutability.PublicImmutableWithConstFieldClass,
                    TypeNames.Mutability.PublicImmutableRecord,
                    TypeNames.Mutability.PublicImmutableParentClass,
                    TypeNames.Mutability.PublicImmutableWithInheritanceClass
                );
        }
    }
}
