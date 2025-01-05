namespace ArchGuard.Filters.Tests.Types
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
            var filters = TypesFromMockedAssembly.All.That.AreEnums();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(new List<string> { TypeNames.InternalEnum, TypeNames.PublicEnum });
        }

        [Fact]
        public void Get_non_enum_types()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.AreNotEnums();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
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
                    TypeNames.PublicAbstractClass,
                    TypeNames.PublicClass,
                    TypeNames.PublicGenericClassWithOneType,
                    TypeNames.PublicGenericClassWithTwoTypes,
                    TypeNames.PublicParentClass,
                    TypeNames.PublicParentClass_InternalNestedClass,
                    TypeNames.PublicParentClass_PrivateNestedClass,
                    TypeNames.PublicParentClass_PublicNestedClass,
                    TypeNames.PublicParentClass_PublicNestedPartialClass,
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
                    TypeNames.PublicStruct
                );
        }

        [Fact]
        public void Get_public_enums()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.AreEnums().And().ArePublic();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(new List<string> { TypeNames.PublicEnum });
        }

        [Fact]
        public void Get_internal_enums()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.AreEnums().And().AreInternal();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(new List<string> { TypeNames.InternalEnum });
        }
    }
}
