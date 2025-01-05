namespace ArchGuard.Filters.Tests
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using ArchGuard.Tests.MockedAssembly.Classes.Public;
    using ArchGuard.Tests.MockedAssembly.Interfaces.Public;
    using FluentAssertions;
    using Xunit;

    public sealed partial class InheritTests
    {
        [Fact]
        public void Inherit_with_type_as_argument()
        {
            // Arrange
#pragma warning disable CA2263 // Prefer generic overload when type is known
            var filters = TypesFromMockedAssembly.All.That.Inherit(typeof(PublicAbstractClass));
#pragma warning restore CA2263 // Prefer generic overload when type is known

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(new List<string> { TypeNames.PublicClass });
        }

        [Fact]
        public void Inherit_with_generic_overload()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.Inherit<PublicAbstractClass>();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(new List<string> { TypeNames.PublicClass });
        }

        [Fact]
        public void Inherit_with_type_as_argument_should_Throw_ArgumentException_when_type_is_not_class()
        {
            // Arrange
#pragma warning disable CA2263 // Prefer generic overload when type is known
            Action act = () =>
                TypesFromMockedAssembly
                    .All.That.Inherit(typeof(IPublicInterface))
                    .GetTypes()
                    .GetFullNames();
#pragma warning restore CA2263 // Prefer generic overload when type is known

            // Assert
            act.Should().ThrowExactly<ArgumentException>().WithMessage("Type must be a class*");
        }

        [Fact]
        public void Inherit_with_generic_overload_should_Throw_ArgumentException_when_type_is_not_class()
        {
            // Arrange
            Action act = () =>
                TypesFromMockedAssembly
                    .All.That.Inherit<IPublicInterface>()
                    .GetTypes()
                    .GetFullNames();

            // Assert
            act.Should().ThrowExactly<ArgumentException>().WithMessage("Type must be a class*");
        }

        [Fact]
        public void DoNotInherit_with_type_as_argument()
        {
            // Arrange
#pragma warning disable CA2263 // Prefer generic overload when type is known
            var filters = TypesFromMockedAssembly.All.That.DoNotInherit(
                typeof(PublicAbstractClass)
            );
#pragma warning restore CA2263 // Prefer generic overload when type is known

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
        public void DoNotInherit_with_generic_overload()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.DoNotInherit<PublicAbstractClass>();

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
        public void DoNotInherit_with_type_as_argument_should_Throw_ArgumentException_when_type_is_not_class()
        {
            // Arrange
#pragma warning disable CA2263 // Prefer generic overload when type is known
            Action act = () =>
                TypesFromMockedAssembly
                    .All.That.DoNotInherit(typeof(IPublicInterface))
                    .GetTypes()
                    .GetFullNames();
#pragma warning restore CA2263 // Prefer generic overload when type is known

            // Assert
            act.Should().ThrowExactly<ArgumentException>().WithMessage("Type must be a class*");
        }

        [Fact]
        public void DoNotInherit_with_generic_overload_should_Throw_ArgumentException_when_type_is_not_class()
        {
            // Arrange
            Action act = () =>
                TypesFromMockedAssembly
                    .All.That.DoNotInherit<IPublicInterface>()
                    .GetTypes()
                    .GetFullNames();

            // Assert
            act.Should().ThrowExactly<ArgumentException>().WithMessage("Type must be a class*");
        }
    }
}
