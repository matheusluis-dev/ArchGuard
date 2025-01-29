namespace ArchGuard.Filters.Tests.Types
{
    using System.Collections.Generic;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using ArchGuard.Type.Filters.EntryPoint;
    using ArchGuard.Type.Filters.Sequences;
    using FluentAssertions;
    using Xunit;

    public sealed class LogicalOperatorsTests
    {
        [Fact]
        public void That_with_one_filter()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That(t => t.AreClasses());

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
        public void That_nested_And()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That(t => t.AreClasses().And.AreNotPublic());

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    new List<string>
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
                        TypeNames.PublicParentClass_InternalNestedClass,
                        TypeNames.PublicParentClass_PrivateNestedClass,
                    }
                );
        }

        [Fact]
        public void And()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.AreClasses().And.AreNotPublic();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    new List<string>
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
                        TypeNames.PublicParentClass_InternalNestedClass,
                        TypeNames.PublicParentClass_PrivateNestedClass,
                    }
                );
        }

        [Fact]
        public void And_and()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.AreClasses()
                .And.AreNotPublic()
                .And.AreSealed();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    new List<string> {
#if NET7_0_OR_GREATER
                        TypeNames.FileSealedClass,
#endif
                        TypeNames.InternalSealedClass }
                );
        }

        [Fact]
        public void Or()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.AreInterfaces().Or.AreEnums();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    new List<string>
                    {
                        TypeNames.IInternalInterface,
                        TypeNames.IPublicInterface,
                        TypeNames.InternalEnum,
                        TypeNames.PublicEnum,
                    }
                );
        }

        [Fact]
        public void And_or()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.AreClasses()
                .And.ArePublic()
                .Or.AreInterfaces();

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
                    TypeNames.PublicStaticClass,
                    TypeNames.IInternalInterface,
                    TypeNames.IPublicInterface
                );
        }

        [Fact]
        public void And_or_and()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.AreClasses()
                .And.ArePublic()
                .Or.AreInterfaces()
                .And.AreInternal();

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
                    TypeNames.PublicStaticClass,
                    TypeNames.IInternalInterface
                );
        }

        [Fact]
        public void And_or_and_or()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.AreClasses()
                .And.ArePublic()
                .Or.AreInterfaces()
                .And.AreInternal()
                .Or.AreEnums();

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
                    TypeNames.PublicStaticClass,
                    TypeNames.IInternalInterface,
                    TypeNames.InternalEnum,
                    TypeNames.PublicEnum
                );
        }

        [Fact]
        public void And_grouped()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.AreClasses()
                .And(a => a.AreNotPublic().And.AreSealed());

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    new List<string> {
#if NET7_0_OR_GREATER
                        TypeNames.FileSealedClass,
#endif
                        TypeNames.InternalSealedClass }
                );
        }

        [Fact]
        public void And_double_grouped()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.AreClasses()
                .And(a => a.AreNotPublic().And(b => b.AreSealed()));

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    new List<string> {
#if NET7_0_OR_GREATER
                        TypeNames.FileSealedClass,
#endif
                        TypeNames.InternalSealedClass }
                );
        }

        [Fact]
        public void Or_grouped()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.AreClasses()
                .And.ArePublic()
                .Or(o => o.AreInterfaces().And.AreInternal());

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    new List<string>
                    {
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
                        TypeNames.IInternalInterface,
                    }
                );
        }
    }
}
