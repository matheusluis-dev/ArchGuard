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
                .And.ImplementInterface(typeof(IPublicInterface1));

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.ImplementInterface.PublicImplementIPublicInterface1Class,
                    TypeNames.ImplementInterface.PublicImplementPublicInterface1ByInheritanceClass,
                    TypeNames
                        .ImplementInterface
                        .PublicParentImplementPublicInterface1ByInheritanceClass
                );
        }

        [Fact]
        public void ImplementsInterface_with_type_as_argument_and_params()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.ImplementInterface)
                .And.ImplementInterface(typeof(IPublicInterface1), typeof(IPublicInterface2));

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.ImplementInterface.PublicImplementIPublicInterface1Class,
                    TypeNames.ImplementInterface.PublicImplementPublicInterface1ByInheritanceClass,
                    TypeNames
                        .ImplementInterface
                        .PublicParentImplementPublicInterface1ByInheritanceClass,
                    TypeNames.ImplementInterface.PublicImplementPublicInterface2Class
                );
        }

        [Fact]
        public void ImplementsInterface_with_generic_overload()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.ImplementInterface)
                .And.ImplementInterface<IPublicInterface1>();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.ImplementInterface.PublicImplementIPublicInterface1Class,
                    TypeNames.ImplementInterface.PublicImplementPublicInterface1ByInheritanceClass,
                    TypeNames
                        .ImplementInterface
                        .PublicParentImplementPublicInterface1ByInheritanceClass
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
                    .And.ImplementInterface(typeof(PublicImplementIPublicInterface1Class))
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
                    .And.ImplementInterface<PublicImplementIPublicInterface1Class>()
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
                .And.DoNotImplementInterface(typeof(IPublicInterface1));

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.ImplementInterface.IPublicInterface1,
                    TypeNames.ImplementInterface.IPublicInheritIPublicInterface1Interface,
                    TypeNames.ImplementInterface.IPublicInterface2,
                    TypeNames.ImplementInterface.PublicImplementPublicInterface2Class
                );
        }

        [Fact]
        public void DoNotImplementsInterface_with_generic_overload()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.ImplementInterface)
                .And.DoNotImplementInterface<IPublicInterface1>();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.ImplementInterface.IPublicInterface1,
                    TypeNames.ImplementInterface.IPublicInheritIPublicInterface1Interface,
                    TypeNames.ImplementInterface.IPublicInterface2,
                    TypeNames.ImplementInterface.PublicImplementPublicInterface2Class
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
                    .And.DoNotImplementInterface(typeof(PublicImplementIPublicInterface1Class))
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
                    .And.DoNotImplementInterface<PublicImplementIPublicInterface1Class>()
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
                .And.ImplementInterface(typeof(IPublicInterface1));

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .NotContain(TypeNames.ImplementInterface.IPublicInheritIPublicInterface1Interface);
        }

        [Fact]
        public void DoNotImplementInterface_should_not_treat_interface_inheritance_as_interface_implementation()
        {
            // Arrange
            var filters =
                ArchGuard.Tests.Common.MockedAssembly.Inherit.Types.That.DoNotImplementInterface(
                    typeof(IPublicInterface1)
                );

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .Contain(TypeNames.ImplementInterface.IPublicInheritIPublicInterface1Interface);
        }
    }
}
