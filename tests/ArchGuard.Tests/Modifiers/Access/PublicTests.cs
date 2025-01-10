namespace ArchGuard.Filters.Tests.Modifiers.Access
{
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class PublicTests
    {
        [Fact]
        public void Public_types()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ArePublic();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.PublicEnum,
                    TypeNames.IPublicInterface,
#if NET5_0_OR_GREATER
                    TypeNames.PublicRecord,
                    TypeNames.PublicPartialRecord,
                    TypeNames.PublicSealedRecord,
#endif
                    TypeNames.PublicAbstractClass,
                    TypeNames.PublicClass,
                    TypeNames.PublicGenericClassWithOneType,
                    TypeNames.PublicGenericClassWithTwoTypes,
                    TypeNames.PublicParentClass,
                    TypeNames.PublicParentClass_PublicNestedClass,
                    TypeNames.PublicParentClass_PublicNestedPartialClass,
                    TypeNames.PublicPartialClass,
                    TypeNames.PublicSealedClass,
                    TypeNames.PublicStaticClass,
                    TypeNames.PublicStruct
                );
        }

        [Fact]
        public void Non_public_types()
        {
            var filters = TypesFromMockedAssembly.All.That.AreNotPublic();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.InternalEnum,
                    TypeNames.IInternalInterface,
#if NET5_0_OR_GREATER
                    TypeNames.InternalRecord,
                    TypeNames.InternalPartialRecord,
                    TypeNames.InternalSealedRecord,
#endif
                    TypeNames.InternalClass,
                    TypeNames.InternalPartialClass,
                    TypeNames.InternalSealedClass,
                    TypeNames.InternalStaticClass,
#if NET7_0_OR_GREATER
                    TypeNames.FileClass,
                    TypeNames.FilePartialClass,
                    TypeNames.FileSealedClass,
                    TypeNames.FileStaticClass,
#endif
                    TypeNames.InternalStruct,
                    TypeNames.PublicParentClass_InternalNestedClass,
                    TypeNames.PublicParentClass_PrivateNestedClass
                );
        }
    }
}
