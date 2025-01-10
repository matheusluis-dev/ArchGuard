namespace ArchGuard.Filters.Tests.Types
{
    // TODO: remove new List<string> from tests, not necessary in any runtime
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class ClassesTests
    {
        [Fact]
        public void Get_classes()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.AreClasses();

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
                    TypeNames.PublicStaticClass
                );
        }

        [Fact]
        public void Get_non_class_types()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.AreNotClasses();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.InternalEnum,
                    TypeNames.PublicEnum,
                    TypeNames.IInternalInterface,
                    TypeNames.IPublicInterface,
#if NET5_0_OR_GREATER
                    TypeNames.InternalPartialRecord,
                    TypeNames.InternalRecord,
                    TypeNames.InternalSealedRecord,
                    TypeNames.PublicPartialRecord,
                    TypeNames.PublicRecord,
                    TypeNames.PublicSealedRecord,
#endif
                    TypeNames.InternalStruct,
                    TypeNames.PublicStruct
                );
        }

        [Fact]
        public void Get_public_classes()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.AreClasses().And.ArePublic();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.PublicAbstractClass,
                    TypeNames.PublicClass,
                    TypeNames.PublicGenericClassWithOneType,
                    TypeNames.PublicGenericClassWithTwoTypes,
                    TypeNames.PublicParentClass,
                    TypeNames.PublicParentClass_PublicNestedClass,
                    TypeNames.PublicParentClass_PublicNestedPartialClass,
                    TypeNames.PublicPartialClass,
                    TypeNames.PublicSealedClass,
                    TypeNames.PublicStaticClass
                );
        }

        [Fact]
        public void Get_internal_classes()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.AreClasses().And.AreInternal();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.InternalClass,
                    TypeNames.InternalPartialClass,
                    TypeNames.InternalSealedClass,
                    TypeNames.InternalStaticClass,
                    TypeNames.PublicParentClass_InternalNestedClass
                );
        }

        [Fact]
        public void Get_partial_classes()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.AreClasses().And.ArePartial();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.FilePartialClass,
                    TypeNames.InternalPartialClass,
                    TypeNames.PublicParentClass_PublicNestedPartialClass,
                    TypeNames.PublicPartialClass
                );
        }

        [Fact]
        public void Get_sealed_classes()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.AreClasses().And.AreSealed();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
#if NET7_0_OR_GREATER
                    TypeNames.FileSealedClass,
#endif
                    TypeNames.InternalSealedClass, TypeNames.PublicSealedClass);
        }

#if NET7_0_OR_GREATER
        [Fact]
        public void Get_file_scoped_classes()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.AreClasses().And.AreFileScoped();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.FileClass,
                    TypeNames.FilePartialClass,
                    TypeNames.FileSealedClass,
                    TypeNames.FileStaticClass
                );
        }
#endif
    }
}
