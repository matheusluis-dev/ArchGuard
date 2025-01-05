#if NET5_0_OR_GREATER
namespace ArchGuard.Filters.Tests.Types
{
    using System.Collections.Generic;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class RecordsTests
    {
        [Fact]
        public void Get_records()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.AreRecords();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    new List<string>
                    {
                        TypeNames.InternalPartialRecord,
                        TypeNames.InternalRecord,
                        TypeNames.InternalSealedRecord,
                        TypeNames.PublicPartialRecord,
                        TypeNames.PublicRecord,
                        TypeNames.PublicSealedRecord,
                    }
                );
        }

        [Fact]
        public void Get_non_record_types()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.AreNotRecords();

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
                    TypeNames.InternalEnum,
                    TypeNames.PublicEnum,
                    TypeNames.InternalStruct,
                    TypeNames.PublicStruct
                );
        }

        [Fact]
        public void Get_public_records()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.AreRecords().And.ArePublic();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    new List<string>
                    {
                        TypeNames.PublicPartialRecord,
                        TypeNames.PublicRecord,
                        TypeNames.PublicSealedRecord,
                    }
                );
        }

        [Fact]
        public void Get_internal_records()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.AreRecords().And.AreInternal();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    new List<string>
                    {
                        TypeNames.InternalPartialRecord,
                        TypeNames.InternalRecord,
                        TypeNames.InternalSealedRecord,
                    }
                );
        }

        [Fact]
        public void Get_partial_records()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.AreRecords().And.ArePartial();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    new List<string>
                    {
                        TypeNames.InternalPartialRecord,
                        TypeNames.PublicPartialRecord,
                    }
                );
        }

        [Fact]
        public void Get_sealed_records()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.AreRecords().And.AreSealed();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    new List<string>
                    {
                        TypeNames.InternalSealedRecord,
                        TypeNames.PublicSealedRecord,
                    }
                );
        }
    }
}
#endif
