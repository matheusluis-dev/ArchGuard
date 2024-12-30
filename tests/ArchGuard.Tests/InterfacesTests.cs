namespace ArchGuard.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Library.Types;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using ArchGuard.Tests.MockedAssembly.Classes.Public;
    using FluentAssertions;
    using Xunit;

    public sealed class InterfacesTests
    {
        [Fact]
        public void Get_interfaces()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.IInternalInterface,
                TypeNames.IPublicInterface,
            };
            var filters = TypesFromMockedAssembly.All.That().AreInterfaces();

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_non_interface_types()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.InternalClass,
                TypeNames.InternalPartialClass,
                TypeNames.InternalSealedClass,
                TypeNames.InternalStaticClass,
                TypeNames.PublicClass,
                TypeNames.PublicPartialClass,
                TypeNames.PublicSealedClass,
                TypeNames.PublicStaticClass,
                TypeNames.InternalEnum,
                TypeNames.PublicEnum,
#if NET5_0_OR_GREATER
                TypeNames.InternalRecord,
                TypeNames.InternalPartialRecord,
                TypeNames.InternalSealedRecord,
                TypeNames.PublicRecord,
                TypeNames.PublicPartialRecord,
                TypeNames.PublicSealedRecord,
#endif
                TypeNames.InternalStruct,
                TypeNames.PublicStruct,
            };
            var filters = TypesFromMockedAssembly.All.That().AreNotInterfaces();

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_public_interfaces()
        {
            // Arrange
            var expected = new List<string> { TypeNames.IPublicInterface };
            var filters = TypesFromMockedAssembly.All.That().AreInterfaces().And().ArePublic();

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_internal_interfaces()
        {
            // Arrange
            var expected = new List<string> { TypeNames.IInternalInterface };
            var filters = TypesFromMockedAssembly.All.That().AreInterfaces().And().AreInternal();

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }
    }
}
