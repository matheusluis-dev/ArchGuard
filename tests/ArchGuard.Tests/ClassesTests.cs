namespace ArchGuard.Tests
{
    using System.Collections.Generic;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using ArchGuard.Tests.Common.Types.Builder;
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
                TypeNamesRefactorStatic.InternalClass,
                TypeNamesRefactorStatic.InternalPartialClass,
                TypeNamesRefactorStatic.InternalSealedClass,
                TypeNamesRefactorStatic.InternalStaticClass,
                TypeNamesRefactorStatic.PublicClass,
                TypeNamesRefactorStatic.PublicPartialClass,
                TypeNamesRefactorStatic.PublicSealedClass,
                TypeNamesRefactorStatic.PublicStaticClass,
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
                TypeNamesRefactorStatic.IInternalInterface,
                TypeNamesRefactorStatic.IPublicInterface,
                TypeNamesRefactorStatic.InternalEnum,
                TypeNamesRefactorStatic.PublicEnum,
#if NET5_0_OR_GREATER
                TypeNamesRefactorStatic.InternalRecord,
                TypeNamesRefactorStatic.InternalPartialRecord,
                TypeNamesRefactorStatic.InternalSealedRecord,
                TypeNamesRefactorStatic.PublicRecord,
                TypeNamesRefactorStatic.PublicPartialRecord,
                TypeNamesRefactorStatic.PublicSealedRecord,
#endif
                TypeNamesRefactorStatic.InternalStruct,
                TypeNamesRefactorStatic.PublicStruct,
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
                TypeNamesRefactorStatic.PublicClass,
                TypeNamesRefactorStatic.PublicPartialClass,
                TypeNamesRefactorStatic.PublicSealedClass,
                TypeNamesRefactorStatic.PublicStaticClass,
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
                TypeNamesRefactorStatic.InternalClass,
                TypeNamesRefactorStatic.InternalPartialClass,
                TypeNamesRefactorStatic.InternalSealedClass,
                TypeNamesRefactorStatic.InternalStaticClass,
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
                TypeNamesRefactorStatic.PublicPartialClass,
                TypeNamesRefactorStatic.InternalPartialClass,
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
                TypeNamesRefactorStatic.InternalSealedClass,
                TypeNamesRefactorStatic.PublicSealedClass,
            };
            var filters = TypesFromMockedAssembly.All.That().AreClasses().And().AreSealed();

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }
    }
}
