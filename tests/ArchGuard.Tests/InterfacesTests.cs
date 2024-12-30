namespace ArchGuard.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Library.Types;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using ArchGuard.Tests.Common.Types.Builder;
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
                TypeNamesRefactorStatic.IInternalInterface,
                TypeNamesRefactorStatic.IPublicInterface,
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
                TypeNamesRefactorStatic.InternalClass,
                TypeNamesRefactorStatic.InternalPartialClass,
                TypeNamesRefactorStatic.InternalSealedClass,
                TypeNamesRefactorStatic.InternalStaticClass,
                TypeNamesRefactorStatic.PublicClass,
                TypeNamesRefactorStatic.PublicPartialClass,
                TypeNamesRefactorStatic.PublicSealedClass,
                TypeNamesRefactorStatic.PublicStaticClass,
                TypeNamesRefactorStatic.InternalEnum,
                TypeNamesRefactorStatic.PublicEnum,
#if NET5_0_OR_GREATER
                TypeNamesRefactorStatic.InternalRecord,
                TypeNamesRefactorStatic.InternalPartialRecord,
                TypeNamesRefactorStatic.InternalSealedRecord,
                TypeNamesRefactorStatic.PublicRecord,
                TypeNamesRefactorStatic.PublicPartialRecord,
                TypeNamesRefactorStatic.PublicSealedRecord,
#endif
                TypeNamesRefactorStatic.InternalStruct,
                TypeNamesRefactorStatic.PublicStruct,
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
            var expected = new List<string> { TypeNamesRefactorStatic.IPublicInterface };
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
            var expected = new List<string> { TypeNamesRefactorStatic.IInternalInterface };
            var filters = TypesFromMockedAssembly.All.That().AreInterfaces().And().AreInternal();

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }
    }
}
