namespace ArchGuard.Tests
{
    using System;
    using System.Linq;
    using ArchGuard.Library.Types;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.MockedAssembly.Classes.Public;
    using FluentAssertions;
    using Xunit;

    public sealed class InterfacesTests
    {
        [Fact]
        public void Get_interfaces()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .AreInterfaces()
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.Interfaces);
        }

        [Fact]
        public void Get_non_interface_types()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;
            var nonInterfaceTypes = TypeNames.Types.Except(
                TypeNames.Interfaces,
                StringComparer.Ordinal
            );

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .AreNotInterfaces()
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(nonInterfaceTypes);
        }

        [Fact]
        public void Get_public_interfaces()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .AreInterfaces()
                .And()
                .ArePublic()
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.InterfacesPublic);
        }

        [Fact]
        public void Get_internal_interfaces()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .AreInterfaces()
                .And()
                .AreInternal()
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.InterfacesInternal);
        }
    }
}
