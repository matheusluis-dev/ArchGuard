namespace ArchGuard.Tests.Modifiers
{
    using System.Collections.Generic;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class NestedTests
    {
        [Fact]
        public void Nested_types()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.PublicParentClass_InternalNestedClass,
                TypeNames.PublicParentClass_PrivateNestedClass,
                TypeNames.PublicParentClass_PublicNestedClass,
                TypeNames.PublicParentClass_PublicNestedPartialClass,
            };
            var filters = TypesFromMockedAssembly.All.That().AreNested();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Non_nested_types()
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
                TypeNames.PublicPartialClass,
                TypeNames.PublicSealedClass,
                TypeNames.PublicStaticClass,
                TypeNames.IInternalInterface,
                TypeNames.IPublicInterface,
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
            var filters = TypesFromMockedAssembly.All.That().AreNotNested();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }
    }
}
