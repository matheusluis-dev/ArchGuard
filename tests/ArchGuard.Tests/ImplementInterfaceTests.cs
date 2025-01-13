namespace ArchGuard.Filters.Tests
{
    using System;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using ArchGuard.Tests.MockedAssembly.ImplementInterface;
    using FluentAssertions;
    using Xunit;

    public sealed class ImplementInterfaceTests
    {
        [Fact]
        public void ImplementsInterface_with_type_as_argument()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.ImplementInterface)
                .And.ImplementInterface(typeof(IPublicInterface));

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.ImplementInterface.PublicImplementIPublicInterfaceClass,
                    TypeNames.ImplementInterface.PublicImplementPublicInterfaceByInheritanceClass,
                    TypeNames
                        .ImplementInterface
                        .PublicParentImplementPublicInterfaceByInheritanceClass
                );
        }

        //[Fact]
        //public void ImplementsInterface_with_type_as_argument_and_params()
        //{
        //    // Arrange
        //    var filters = TypesFromMockedAssembly.All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.ImplementInterface).And.ImplementInterface(
        //        typeof(IPublicInterface),
        //        typeof(IInternalInterface)
        //    );

        //    // Act
        //    var types = filters.GetTypes().GetFullNames();

        //    // Assert
        //    types.Should().BeEquivalentTo(TypeNames.InternalClass, TypeNames.PublicClass);
        //}

        [Fact]
        public void ImplementsInterface_with_generic_overload()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.ImplementInterface)
                .And.ImplementInterface<IPublicInterface>();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.ImplementInterface.PublicImplementIPublicInterfaceClass,
                    TypeNames.ImplementInterface.PublicImplementPublicInterfaceByInheritanceClass,
                    TypeNames
                        .ImplementInterface
                        .PublicParentImplementPublicInterfaceByInheritanceClass
                );
        }

        [Fact]
        public void ImplementsInterface_with_type_as_argument_should_Throw_ArgumentException_when_type_is_not_class()
        {
            // Arrange
            Action act = () =>
                TypesFromMockedAssembly
                    .All.That.ResideInNamespace(
                        ArchGuard.Tests.Common.Namespaces.ImplementInterface
                    )
                    .And.ImplementInterface(typeof(PublicImplementIPublicInterfaceClass))
                    .GetTypes(StringComparison.Ordinal)
                    .GetFullNames();

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
                    .All.That.ResideInNamespace(
                        ArchGuard.Tests.Common.Namespaces.ImplementInterface
                    )
                    .And.ImplementInterface<PublicImplementIPublicInterfaceClass>()
                    .GetTypes(StringComparison.Ordinal)
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
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.ImplementInterface)
                .And.DoNotImplementInterface(typeof(IPublicInterface));

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.ImplementInterface.IPublicInterface,
                    TypeNames.ImplementInterface.IPublicInheritIPublicInterfaceInterface
                );
        }

        [Fact]
        public void DoNotImplementsInterface_with_generic_overload()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.ImplementInterface)
                .And.DoNotImplementInterface<IPublicInterface>();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.ImplementInterface.IPublicInterface,
                    TypeNames.ImplementInterface.IPublicInheritIPublicInterfaceInterface
                );
        }

        [Fact]
        public void DoNotImplementsInterface_with_type_as_argument_should_Throw_ArgumentException_when_type_is_not_class()
        {
            // Arrange
            Action act = () =>
                TypesFromMockedAssembly
                    .All.That.ResideInNamespace(
                        ArchGuard.Tests.Common.Namespaces.ImplementInterface
                    )
                    .And.DoNotImplementInterface(typeof(PublicImplementIPublicInterfaceClass))
                    .GetTypes(StringComparison.Ordinal)
                    .GetFullNames();

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
                    .All.That.ResideInNamespace(
                        ArchGuard.Tests.Common.Namespaces.ImplementInterface
                    )
                    .And.DoNotImplementInterface<PublicImplementIPublicInterfaceClass>()
                    .GetTypes(StringComparison.Ordinal)
                    .GetFullNames();

            // Assert
            act.Should()
                .ThrowExactly<ArgumentException>()
                .WithMessage("Type must be an interface*");
        }

        [Fact]
        public void ImplementInterface_should_not_treat_interface_inheritance_as_interface_implementation()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.ImplementInterface)
                .And.ImplementInterface(typeof(IPublicInterface));

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .NotContain(TypeNames.ImplementInterface.IPublicInheritIPublicInterfaceInterface);
        }

        [Fact]
        public void DoNotImplementInterface_should_not_treat_interface_inheritance_as_interface_implementation()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.ImplementInterface)
                .And.DoNotImplementInterface(typeof(IPublicInterface));

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .Contain(TypeNames.ImplementInterface.IPublicInheritIPublicInterfaceInterface);
        }
    }
}
