namespace ArchGuard.Filters.Tests
{
    using System;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class GenericTests
    {
        [Fact]
        public void AreGeneric()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.Generics)
                .And.AreGeneric();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.Generics.IPublicGenericOneTypeInterface,
                    TypeNames.Generics.IPublicGenericTwoTypesInterface,
                    TypeNames.Generics.PublicGenericOneTypeClass,
                    TypeNames.Generics.PublicGenericTwoTypesClass,
                    TypeNames.Generics.PublicParentNonGenericInheritGenericClass,
                    TypeNames.Generics.PublicGenericInheritGenericClass,
                    TypeNames.Generics.PublicParentGenericInheritGenericClass,
                    TypeNames.Generics.PublicGenericOneTypeArgumentInheritTwoTypesArgumentClass,
                    TypeNames.Generics.PublicParentGenericOneTypeArgumentInheritTwoTypesArgumentClass
                );
        }

        [Fact]
        public void AreNotGeneric()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.Generics)
                .And.AreNotGeneric();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.Generics.IPublicNonGenericInterface,
                    TypeNames.Generics.PublicNonGenericClass,
                    TypeNames.Generics.PublicNonGenericInheritGenericClass
                );
        }
    }
}
