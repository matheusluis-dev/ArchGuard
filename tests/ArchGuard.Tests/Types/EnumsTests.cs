namespace ArchGuard.Tests.Types
{
    using System.Collections.Generic;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class EnumsTests
    {
        [Fact]
        public void Get_enums()
        {
            // Arrange
            var expected = new List<string> { TypeNames.InternalEnum, TypeNames.PublicEnum };
            var filters = TypesFromMockedAssembly.All.That().AreEnums();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_non_enum_types()
        {
            // Arrange
            var expected = new List<string>
            {
#if NET7_0_OR_GREATER
                TypeNames.FileClass,
                TypeNames.FilePartialClass,
                TypeNames.FileSealedClass,
                TypeNames.FileStaticClass,
#endif
                TypeNames.InternalClass,
                TypeNames.InternalPartialClass,
                TypeNames.InternalSealedClass,
                TypeNames.InternalStaticClass,
                TypeNames.PublicClass,
                TypeNames.PublicParentClass,
                TypeNames.PublicParentClass_InternalNestedClass,
                TypeNames.PublicParentClass_PrivateNestedClass,
                TypeNames.PublicParentClass_PublicNestedClass,
                TypeNames.PublicPartialClass,
                TypeNames.PublicSealedClass,
                TypeNames.PublicStaticClass,
                TypeNames.IInternalInterface,
                TypeNames.IPublicInterface,
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
            var filters = TypesFromMockedAssembly.All.That().AreNotEnums();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_public_enums()
        {
            // Arrange
            var expected = new List<string> { TypeNames.PublicEnum };
            var filters = TypesFromMockedAssembly.All.That().AreEnums().And().ArePublic();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_internal_enums()
        {
            // Arrange
            var expected = new List<string> { TypeNames.InternalEnum };
            var filters = TypesFromMockedAssembly.All.That().AreEnums().And().AreInternal();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }
    }
}
