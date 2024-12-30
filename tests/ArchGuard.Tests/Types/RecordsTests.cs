#if NET5_0_OR_GREATER
namespace ArchGuard.Tests.Types
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
            var expected = new List<string>
            {
                TypeNames.InternalPartialRecord,
                TypeNames.InternalRecord,
                TypeNames.InternalSealedRecord,
                TypeNames.PublicPartialRecord,
                TypeNames.PublicRecord,
                TypeNames.PublicSealedRecord,
            };
            var filters = TypesFromMockedAssembly.All.That().AreRecords();

            // Act
            var types = filters.GetTypes().GetNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_non_record_types()
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
                TypeNames.PublicPartialClass,
                TypeNames.PublicSealedClass,
                TypeNames.PublicStaticClass,
                TypeNames.IInternalInterface,
                TypeNames.IPublicInterface,
                TypeNames.InternalEnum,
                TypeNames.PublicEnum,
                TypeNames.InternalStruct,
                TypeNames.PublicStruct,
            };
            var filters = TypesFromMockedAssembly.All.That().AreNotRecords();

            // Act
            var types = filters.GetTypes().GetNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_public_records()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.PublicPartialRecord,
                TypeNames.PublicRecord,
                TypeNames.PublicSealedRecord,
            };
            var filters = TypesFromMockedAssembly.All.That().AreRecords().And().ArePublic();

            // Act
            var types = filters.GetTypes().GetNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_internal_records()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.InternalPartialRecord,
                TypeNames.InternalRecord,
                TypeNames.InternalSealedRecord,
            };
            var filters = TypesFromMockedAssembly.All.That().AreRecords().And().AreInternal();

            // Act
            var types = filters.GetTypes().GetNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_partial_records()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.InternalPartialRecord,
                TypeNames.PublicPartialRecord,
            };
            var filters = TypesFromMockedAssembly.All.That().AreRecords().And().ArePartial();

            // Act
            var types = filters.GetTypes().GetNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_sealed_records()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.InternalSealedRecord,
                TypeNames.PublicSealedRecord,
            };
            var filters = TypesFromMockedAssembly.All.That().AreRecords().And().AreSealed();

            // Act
            var types = filters.GetTypes().GetNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }
    }
}
#endif
