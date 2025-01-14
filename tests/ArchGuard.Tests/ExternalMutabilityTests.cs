namespace ArchGuard.Filters.Tests
{
    using System;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class ExternalMutabilityTests
    {
        [Fact]
        public void AreExternallyMutable()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.ExternalMutability)
                .And.AreExternallyMutable();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames
                        .ExternalMutability
                        .PublicExternalMutableWithMethodUpdatingPrivateFieldClass,
                    TypeNames
                        .ExternalMutability
                        .PublicExternalMutableWithMethodUpdatingPrivatePropertyClass,
                    TypeNames
                        .ExternalMutability
                        .PublicExternalMutableWithMethodUpdatingPublicPropertyPrivateSetClass,
                    TypeNames
                        .ExternalMutability
                        .PublicExternalMutableWithGetMethodUpdatingPrivateFieldClass,
                    TypeNames
                        .ExternalMutability
                        .PublicExternalMutableWithSetMethodUpdatingPrivateFieldClass,
                    TypeNames
                        .ExternalMutability
                        .PublicExternalMutableWithMethodCallingMethodUpdatePublicPropertyPrivateSetClass
                );
        }

        [Fact]
        public void AreExternallyImmutable()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.ExternalMutability)
                .And.AreExternallyImmutable();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames
                        .ExternalMutability
                        .PublicExternalImmutableWithPrivateFieldNonReadonlyClass,
                    TypeNames.ExternalMutability.PublicExternalImmutableEmptyClass,
                    TypeNames.ExternalMutability.PublicExternalImmutableWithReadonlyFieldClass,
                    TypeNames.ExternalMutability.PublicExternalImmutableWithGetOnlyPropertyClass,
                    TypeNames.ExternalMutability.PublicExternalImmutableWithInitPropertyClass,
                    TypeNames
                        .ExternalMutability
                        .PublicExternalImmutableWithPublicPropertyPrivateSetClass
                );
        }
    }
}
