namespace ArchGuard.Filters.Tests
{
    using System;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using ArchGuard.Tests.MockedAssembly.Classes.Public;
    using ArchGuard.Tests.MockedAssembly.Interfaces.Internal;
    using ArchGuard.Tests.MockedAssembly.Interfaces.Public;
    using FluentAssertions;
    using Xunit;

    public sealed class ImplementsInterfaceTests
    {
        [Fact]
        public void ImplementsInterface_with_type_as_argument()
        {
            // Arrange
#pragma warning disable CA2263 // Prefer generic overload when type is known
            var filters = TypesFromMockedAssembly.All.That.ImplementInterface(
                typeof(IPublicInterface)
            );
#pragma warning restore CA2263 // Prefer generic overload when type is known

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.PublicClass.AsStringList());
        }

        [Fact]
        public void ImplementsInterface_with_type_as_argument_and_params()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ImplementInterface(
                typeof(IPublicInterface),
                typeof(IInternalInterface)
            );

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.InternalClass, TypeNames.PublicClass);
        }

        [Fact]
        public void ImplementsInterface_with_generic_overload()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ImplementInterface<IPublicInterface>();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.PublicClass.AsStringList());
        }

        [Fact]
        public void ImplementsInterface_with_type_as_argument_should_Throw_ArgumentException_when_type_is_not_class()
        {
            // Arrange
#pragma warning disable CA2263 // Prefer generic overload when type is known
            Action act = () =>
                TypesFromMockedAssembly
                    .All.That.ImplementInterface(typeof(PublicAbstractClass))
                    .GetTypes()
                    .GetFullNames();
#pragma warning restore CA2263 // Prefer generic overload when type is known

            // Assert
            act.Should()
                .ThrowExactly<ArgumentException>()
                .WithMessage("Type must be an interface*");
        }

        [Fact]
        public void ImplementsInterface_with_generic_overload_should_Throw_ArgumentException_when_type_is_not_class()
        {
            // Arrange
            Action act = () =>
                TypesFromMockedAssembly
                    .All.That.ImplementInterface<PublicAbstractClass>()
                    .GetTypes()
                    .GetFullNames();

            // Assert
            act.Should()
                .ThrowExactly<ArgumentException>()
                .WithMessage("Type must be an interface*");
        }

        [Fact]
        public void DoNotImplementsInterface_with_type_as_argument()
        {
            // Arrange
#pragma warning disable CA2263 // Prefer generic overload when type is known
            var filters = TypesFromMockedAssembly.All.That.DoNotImplementsInterface(
                typeof(IPublicInterface)
            );
#pragma warning restore CA2263 // Prefer generic overload when type is known

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.FileClass,
                    TypeNames.FilePartialClass,
                    TypeNames.FileSealedClass,
                    TypeNames.FileStaticClass,
                    TypeNames.InternalClass,
                    TypeNames.InternalPartialClass,
                    TypeNames.InternalSealedClass,
                    TypeNames.InternalStaticClass,
                    TypeNames.PublicAbstractClass,
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
                    TypeNames.InternalEnum,
                    TypeNames.PublicEnum,
                    TypeNames.IInternalInterface,
                    TypeNames.IPublicInterface,
                    TypeNames.InternalRecord,
                    TypeNames.InternalPartialRecord,
                    TypeNames.InternalSealedRecord,
                    TypeNames.PublicRecord,
                    TypeNames.PublicPartialRecord,
                    TypeNames.PublicSealedRecord,
                    TypeNames.InternalStruct,
                    TypeNames.PublicStruct
                );
        }

        [Fact]
        public void DoNotImplementsInterface_with_generic_overload()
        {
            // Arrange
            var filters =
                TypesFromMockedAssembly.All.That.DoNotImplementInterface<IPublicInterface>();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.FileClass,
                    TypeNames.FilePartialClass,
                    TypeNames.FileSealedClass,
                    TypeNames.FileStaticClass,
                    TypeNames.InternalClass,
                    TypeNames.InternalPartialClass,
                    TypeNames.InternalSealedClass,
                    TypeNames.InternalStaticClass,
                    TypeNames.PublicAbstractClass,
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
                    TypeNames.InternalEnum,
                    TypeNames.PublicEnum,
                    TypeNames.IInternalInterface,
                    TypeNames.IPublicInterface,
                    TypeNames.InternalRecord,
                    TypeNames.InternalPartialRecord,
                    TypeNames.InternalSealedRecord,
                    TypeNames.PublicRecord,
                    TypeNames.PublicPartialRecord,
                    TypeNames.PublicSealedRecord,
                    TypeNames.InternalStruct,
                    TypeNames.PublicStruct
                );
        }

        [Fact]
        public void DoNotImplementsInterface_with_type_as_argument_should_Throw_ArgumentException_when_type_is_not_class()
        {
            // Arrange
#pragma warning disable CA2263 // Prefer generic overload when type is known
            Action act = () =>
                TypesFromMockedAssembly
                    .All.That.DoNotImplementsInterface(typeof(PublicAbstractClass))
                    .GetTypes()
                    .GetFullNames();
#pragma warning restore CA2263 // Prefer generic overload when type is known

            // Assert
            act.Should()
                .ThrowExactly<ArgumentException>()
                .WithMessage("Type must be an interface*");
        }

        [Fact]
        public void DoNotImplementsInterface_with_generic_overload_should_Throw_ArgumentException_when_type_is_not_class()
        {
            // Arrange
            Action act = () =>
                TypesFromMockedAssembly
                    .All.That.DoNotImplementInterface<PublicAbstractClass>()
                    .GetTypes()
                    .GetFullNames();

            // Assert
            act.Should()
                .ThrowExactly<ArgumentException>()
                .WithMessage("Type must be an interface*");
        }
    }
}
