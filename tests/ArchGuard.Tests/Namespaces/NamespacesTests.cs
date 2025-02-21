namespace ArchGuard.Filters.Tests.Namespaces
{
    using System;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class NamespacesTests
    {
        [Fact]
        public void Not_reside_in_namespace()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.DoNotResideInNamespace(Namespaces.ClassesPublic);

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
                    TypeNames.PublicStruct
                );
        }

        [Fact]
        public void Not_reside_in_namespace_with_StringComparison()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.DoNotResideInNamespace(
                Namespaces.ClassesPublic.ToUpperInvariant()
            );

            // Act
            var types = filters.GetTypes(StringComparison.OrdinalIgnoreCase).GetFullNames();

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
                    TypeNames.PublicStruct
                );
        }

        [Fact]
        public void Not_reside_in_namespace_with_params()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.DoNotResideInNamespace(
                Namespaces.ClassesPublic,
                Namespaces.ClassesInternal,
                Namespaces.ClassesFile
            );

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
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
                    TypeNames.PublicStruct
                );
        }

        [Fact]
        public void Not_reside_in_namespace_with_params_and_StringComparison()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.DoNotResideInNamespace(
                Namespaces.ClassesPublic.ToUpperInvariant(),
                Namespaces.ClassesInternal.ToUpperInvariant(),
                Namespaces.ClassesFile.ToUpperInvariant()
            );

            // Act
            var types = filters.GetTypes(StringComparison.OrdinalIgnoreCase).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
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
                    TypeNames.PublicStruct
                );
        }

        [Fact]
        public void Reside_in_namespace_containing()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespaceContaining(".Interfaces.");

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.IInternalInterface, TypeNames.IPublicInterface);
        }

        [Fact]
        public void Reside_in_namespace_containing_with_StringComparison()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespaceContaining(".InTeRfAcEs.");

            // Act
            var types = filters.GetTypes(StringComparison.OrdinalIgnoreCase).GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.IInternalInterface, TypeNames.IPublicInterface);
        }

        [Fact]
        public void Reside_in_namespace_containing_with_params()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespaceContaining(".Interfaces.", ".Enums.");

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.InternalEnum,
                    TypeNames.PublicEnum,
                    TypeNames.IInternalInterface,
                    TypeNames.IPublicInterface
                );
        }

        [Fact]
        public void Reside_in_namespace_containing_with_params_and_StringComparison()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespaceContaining(".interfaces.", ".ENUMS.");

            // Act
            var types = filters.GetTypes(StringComparison.OrdinalIgnoreCase).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.InternalEnum,
                    TypeNames.PublicEnum,
                    TypeNames.IInternalInterface,
                    TypeNames.IPublicInterface
                );
        }

        [Fact]
        public void Reside_in_namespace_ending()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespaceEndingWith(".Internal");

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
                    TypeNames.InternalStruct
                );
        }

        [Fact]
        public void Reside_in_namespace_ending_with_StringComparison()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespaceEndingWith(".iNtErNaL");

            // Act
            var types = filters.GetTypes(StringComparison.OrdinalIgnoreCase).GetFullNames();

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
                    TypeNames.InternalStruct
                );
        }

        [Fact]
        public void Reside_in_namespace_ending_with_params()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespaceEndingWith(".Internal", ".Public");

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
#if NET5_0_OR_GREATER
                    TypeNames.InternalRecord,
                    TypeNames.InternalPartialRecord,
                    TypeNames.InternalSealedRecord,
                    TypeNames.PublicRecord,
                    TypeNames.PublicPartialRecord,
                    TypeNames.PublicSealedRecord,
#endif
                    TypeNames.InternalStruct,
                    TypeNames.PublicStruct
                );
        }

        [Fact]
        public void Reside_in_namespace_ending_with_params_and_StringComparison()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespaceEndingWith(".internal", ".PUBLIC");

            // Act
            var types = filters.GetTypes(StringComparison.OrdinalIgnoreCase).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
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
#if NET5_0_OR_GREATER
                    TypeNames.InternalRecord,
                    TypeNames.InternalPartialRecord,
                    TypeNames.InternalSealedRecord,
                    TypeNames.PublicRecord,
                    TypeNames.PublicPartialRecord,
                    TypeNames.PublicSealedRecord,
#endif
                    TypeNames.InternalStruct,
                    TypeNames.PublicStruct
                );
        }
    }
}
