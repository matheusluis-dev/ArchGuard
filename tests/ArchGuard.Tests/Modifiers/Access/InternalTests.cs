namespace ArchGuard.Filters.Tests.Modifiers.Access
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
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(Namespaces.Internal)
                .And.AreInternal();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.Internal.IInternalInterface,
                    TypeNames.Internal.InternalEnum,
                    TypeNames.Internal.InternalClass
                );
        }

        [Fact]
        public void Non_public_types()
        {
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(Namespaces.Internal)
                .And.AreNotInternal();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.Internal.IFileInterface,
                    TypeNames.Internal.FileClass,
                    TypeNames.Internal.FileEnum,
                    TypeNames.Internal.IPublicInterface,
                    TypeNames.Internal.PublicClass,
                    TypeNames.Internal.PublicEnum
                );
        }
    }
}
