#if NET7_0_OR_GREATER
namespace ArchGuard.Tests.Modifiers.Access
{
    using System.Collections.Generic;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class FileTests
    {
        [Fact]
        public void File_scoped_types()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.FileClass,
                TypeNames.FilePartialClass,
                TypeNames.FileSealedClass,
                TypeNames.FileStaticClass,
            };
            var filters = TypesFromMockedAssembly.All.That().AreFileScoped();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Non_file_scoped_types()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.InternalClass,
                TypeNames.InternalPartialClass,
                TypeNames.InternalSealedClass,
                TypeNames.InternalStaticClass,
                TypeNames.PublicClass,
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
                TypeNames.InternalRecord,
                TypeNames.InternalPartialRecord,
                TypeNames.InternalSealedRecord,
                TypeNames.PublicRecord,
                TypeNames.PublicPartialRecord,
                TypeNames.PublicSealedRecord,
                TypeNames.InternalStruct,
                TypeNames.PublicStruct,
            };
            var filters = TypesFromMockedAssembly.All.That().AreNotFileScoped();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }
    }
}
#endif
