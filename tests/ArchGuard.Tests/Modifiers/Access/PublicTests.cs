namespace ArchGuard.Tests.Modifiers.Access
{
    using System.Collections.Generic;
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
            var expected = new List<string>
            {
                TypeNames.PublicEnum,
                TypeNames.IPublicInterface,
#if NET5_0_OR_GREATER
                TypeNames.PublicRecord,
                TypeNames.PublicPartialRecord,
                TypeNames.PublicSealedRecord,
#endif
                TypeNames.PublicAbstractClass,
                TypeNames.PublicClass,
                TypeNames.PublicParentClass,
                TypeNames.PublicParentClass_PublicNestedClass,
                TypeNames.PublicParentClass_PublicNestedPartialClass,
                TypeNames.PublicPartialClass,
                TypeNames.PublicSealedClass,
                TypeNames.PublicStaticClass,
                TypeNames.PublicStruct,
            };
            var filters = TypesFromMockedAssembly.All.That().ArePublic();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Non_public_types()
        {
            var expected = new List<string>
            {
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
            };
            var filters = TypesFromMockedAssembly.All.That().AreNotPublic();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }
    }
}
