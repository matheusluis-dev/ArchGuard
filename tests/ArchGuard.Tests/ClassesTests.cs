namespace ArchGuard.Tests
{
    using System.Collections.Generic;
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
            var expected = new List<string>
            {
                TypeNames.InternalClass,
                TypeNames.InternalPartialClass,
                TypeNames.InternalSealedClass,
                TypeNames.InternalStaticClass,
                TypeNames.PublicClass,
                TypeNames.PublicPartialClass,
                TypeNames.PublicSealedClass,
                TypeNames.PublicStaticClass,
            };
            var filters = TypesFromMockedAssembly.All.That().AreClasses();

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_non_class_types()
        {
            // Arrange
            var expected = new List<string>
            {
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
            var filters = TypesFromMockedAssembly.All.That().AreNotClasses();

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_public_classes()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.PublicClass,
                TypeNames.PublicPartialClass,
                TypeNames.PublicSealedClass,
                TypeNames.PublicStaticClass,
            };
            var filters = TypesFromMockedAssembly.All.That().AreClasses().And().ArePublic();

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_internal_classes()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.InternalClass,
                TypeNames.InternalPartialClass,
                TypeNames.InternalSealedClass,
                TypeNames.InternalStaticClass,
            };
            var filters = TypesFromMockedAssembly.All.That().AreClasses().And().AreInternal();

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_partial_classes()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.PublicPartialClass,
                TypeNames.InternalPartialClass,
            };
            var filters = TypesFromMockedAssembly.All.That().AreClasses().And().ArePartial();

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_sealed_classes()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.InternalSealedClass,
                TypeNames.PublicSealedClass,
            };
            var filters = TypesFromMockedAssembly.All.That().AreClasses().And().AreSealed();

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }
    }
}
