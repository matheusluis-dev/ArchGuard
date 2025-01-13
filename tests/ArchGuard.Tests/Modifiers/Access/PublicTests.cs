namespace ArchGuard.Filters.Tests.Modifiers.Access
{
    using System;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class PublicTests
    {
        [Fact]
        public void Public_types()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(Namespaces.Public)
                .And.ArePublic();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.Public.IPublicInterface,
                    TypeNames.Public.PublicEnum,
                    TypeNames.Public.PublicClass
                );
        }

        [Fact]
        public void Non_public_types()
        {
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(Namespaces.Public)
                .And.AreNotPublic();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.Public.IFileInterface,
                    TypeNames.Public.FileClass,
                    TypeNames.Public.FileEnum,
                    TypeNames.Public.IInternalInterface,
                    TypeNames.Public.InternalClass,
                    TypeNames.Public.InternalEnum
                );
        }
    }
}
