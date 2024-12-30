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

    public sealed class EnumsTests
    {
        [Fact]
        public void Get_enums()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNamesRefactorStatic.InternalEnum,
                TypeNamesRefactorStatic.PublicEnum,
            };
            var filters = TypesFromMockedAssembly.All.That().AreEnums();

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_non_enum_types()
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
                TypeNamesRefactorStatic.IInternalInterface,
                TypeNamesRefactorStatic.IPublicInterface,
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
            var filters = TypesFromMockedAssembly.All.That().AreNotEnums();

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_public_enums()
        {
            // Arrange
            var expected = new List<string> { TypeNamesRefactorStatic.PublicEnum };
            var filters = TypesFromMockedAssembly.All.That().AreEnums().And().ArePublic();

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_internal_enums()
        {
            // Arrange
            var expected = new List<string> { TypeNamesRefactorStatic.InternalEnum };
            var filters = TypesFromMockedAssembly.All.That().AreEnums().And().AreInternal();

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }
    }
}
