namespace ArchGuard.Tests.Namespaces
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
            var expected = new List<string> { TypeNames.PublicEnum };
#pragma warning disable CA1307 // Specify StringComparison for clarity
            var filters = TypesFromMockedAssembly
                .All.That()
                .ResideInNamespace(Namespaces.EnumsPublic);
#pragma warning restore CA1307 // Specify StringComparison for clarity

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Reside_in_namespace_with_StringComparison()
        {
            // Arrange
            var expected = new List<string> { TypeNames.PublicEnum };
            var filters = TypesFromMockedAssembly
                .All.That()
                .ResideInNamespace(Namespaces.EnumsPublic, StringComparison.OrdinalIgnoreCase);

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Reside_in_sub_namespace()
        {
            // Arrange
            var expected = new List<string> { TypeNames.InternalEnum, TypeNames.PublicEnum };
#pragma warning disable CA1307 // Specify StringComparison for clarity
            var filters = TypesFromMockedAssembly
                .All.That()
                .ResideInNamespace("ArchGuard.Tests.MockedAssembly.Enums");
#pragma warning restore CA1307 // Specify StringComparison for clarity

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Reside_in_sub_namespace_with_StringComparison()
        {
            // Arrange
            var expected = new List<string> { TypeNames.InternalEnum, TypeNames.PublicEnum };
            var filters = TypesFromMockedAssembly
                .All.That()
                .ResideInNamespace(
                    "ARCHGUARD.tests.MOCKEDASSEMBLY.enums",
                    StringComparison.OrdinalIgnoreCase
                );

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Reside_in_namespace_should_not_act_as_string_StartsWith()
        {
            // Arrange
#pragma warning disable CA1307 // Specify StringComparison for clarity
            var filters = TypesFromMockedAssembly
                .All.That()
                .ResideInNamespace("ArchGuard.Tests.MockedAssembly.Enu");
#pragma warning restore CA1307 // Specify StringComparison for clarity

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEmpty();
        }

        [Fact]
        public void Reside_in_namespace_should_not_act_as_string_StartsWith_with_StringComparison()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That()
                .ResideInNamespace(
                    "ARCHGUARD.tests.MOCKEDASSEMBLY.enu",
                    StringComparison.OrdinalIgnoreCase
                );

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEmpty();
        }
    }
}
