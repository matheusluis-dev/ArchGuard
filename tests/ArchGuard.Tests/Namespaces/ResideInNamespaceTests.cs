namespace ArchGuard.Filters.Tests.Namespaces
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class ResideInNamespaceTests
    {
        [Fact]
        public void Reside_in_namespace()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespace(
                Namespaces.EnumsPublic
            );

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.PublicEnum.ToList());
        }

        [Fact]
        public void Reside_in_namespace_with_StringComparison()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespace(
                Namespaces.EnumsPublic.ToUpperInvariant()
            );

            // Act
            var types = filters.GetTypes(StringComparison.OrdinalIgnoreCase).GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.PublicEnum.ToList());
        }

        [Fact]
        public void Reside_in_namespace_with_params()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespace(
                Namespaces.EnumsPublic,
                Namespaces.InterfacesPublic
            );

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.PublicEnum, TypeNames.IPublicInterface);
        }

        [Fact]
        public void Reside_in_namespace_with_params_and_StringComparison()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespace(
                Namespaces.EnumsPublic.ToUpperInvariant(),
                Namespaces.InterfacesPublic.ToUpperInvariant()
            );

            // Act
            var types = filters.GetTypes(StringComparison.OrdinalIgnoreCase).GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.PublicEnum, TypeNames.IPublicInterface);
        }

        [Fact]
        public void Reside_in_sub_namespace()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespace(
                "ArchGuard.Tests.MockedAssembly.Enums"
            );

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.InternalEnum, TypeNames.PublicEnum);
        }

        [Fact]
        public void Reside_in_sub_namespace_with_StringComparison()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespace(
                "ARCHGUARD.tests.MOCKEDASSEMBLY.enums"
            );

            // Act
            var types = filters.GetTypes(StringComparison.OrdinalIgnoreCase).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(new List<string> { TypeNames.InternalEnum, TypeNames.PublicEnum });
        }

        [Fact]
        public void Reside_in_namespace_should_not_act_as_string_StartsWith()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespace(
                "ArchGuard.Tests.MockedAssembly.Enu"
            );

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEmpty();
        }
    }
}
