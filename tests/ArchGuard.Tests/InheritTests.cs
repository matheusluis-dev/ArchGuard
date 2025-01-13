namespace ArchGuard.Filters.Tests
{
    using System;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using ArchGuard.Tests.MockedAssembly.Inherit;
    using FluentAssertions;
    using Xunit;

    // TODO: tests with multiple types as params
    public sealed class InheritTests
    {
        [Fact]
        public void Inherit_interface_with_type_as_argument()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.Inherit)
                .And.Inherit(typeof(IPublicInterface));

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.Inherit.IPublicInheritIPublicInterfaceInterface,
                    TypeNames.Inherit.IPublicInheritIPublicInterfaceByInheritanceInterface,
                    TypeNames.Inherit.IPublicParentInheritIPublicInterfaceByInheritanceInterface
                );
        }

        [Fact]
        public void Inherit_interface_with_generic_overload()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.Inherit)
                .And.Inherit<IPublicInterface>();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.Inherit.IPublicInheritIPublicInterfaceInterface,
                    TypeNames.Inherit.IPublicInheritIPublicInterfaceByInheritanceInterface,
                    TypeNames.Inherit.IPublicParentInheritIPublicInterfaceByInheritanceInterface
                );
        }

        [Fact]
        public void Inherit_class_with_type_as_argument()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.Inherit)
                .And.Inherit(typeof(PublicClass));

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.Inherit.PublicInheritPublicClassClass,
                    TypeNames.Inherit.PublicInheritPublicClassByInheritanceClass,
                    TypeNames.Inherit.PublicParentInheritPublicClassByInheritanceClass
                );
        }

        [Fact]
        public void Inherit_class_with_generic_overload()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.Inherit)
                .And.Inherit<PublicClass>();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.Inherit.PublicInheritPublicClassClass,
                    TypeNames.Inherit.PublicInheritPublicClassByInheritanceClass,
                    TypeNames.Inherit.PublicParentInheritPublicClassByInheritanceClass
                );
        }

        [Fact]
        public void DoNotInherit_interface_with_type_as_argument()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.Inherit)
                .And.DoNotInherit(typeof(IPublicInterface));

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.Inherit.IPublicInterface,
                    TypeNames.Inherit.PublicClass,
                    TypeNames.Inherit.PublicImplementIPublicInterfaceClass,
                    TypeNames.Inherit.PublicInheritPublicClassByInheritanceClass,
                    TypeNames.Inherit.PublicParentInheritPublicClassByInheritanceClass,
                    TypeNames.Inherit.PublicInheritPublicClassClass
                );
        }

        [Fact]
        public void DoNotInherit_interface_with_generic_overload()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.Inherit)
                .And.DoNotInherit<IPublicInterface>();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.Inherit.IPublicInterface,
                    TypeNames.Inherit.PublicClass,
                    TypeNames.Inherit.PublicImplementIPublicInterfaceClass,
                    TypeNames.Inherit.PublicInheritPublicClassByInheritanceClass,
                    TypeNames.Inherit.PublicParentInheritPublicClassByInheritanceClass,
                    TypeNames.Inherit.PublicInheritPublicClassClass
                );
        }

        [Fact]
        public void DoNotInherit_class_with_type_as_argument()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.Inherit)
                .And.DoNotInherit(typeof(PublicClass));

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.Inherit.IPublicInheritIPublicInterfaceInterface,
                    TypeNames.Inherit.IPublicInheritIPublicInterfaceByInheritanceInterface,
                    TypeNames.Inherit.IPublicParentInheritIPublicInterfaceByInheritanceInterface,
                    TypeNames.Inherit.IPublicInterface,
                    TypeNames.Inherit.PublicClass,
                    TypeNames.Inherit.PublicImplementIPublicInterfaceClass
                );
        }

        [Fact]
        public void DoNotInherit_class_with_generic_overload()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.Inherit)
                .And.DoNotInherit<PublicClass>();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.Inherit.IPublicInheritIPublicInterfaceInterface,
                    TypeNames.Inherit.IPublicInheritIPublicInterfaceByInheritanceInterface,
                    TypeNames.Inherit.IPublicParentInheritIPublicInterfaceByInheritanceInterface,
                    TypeNames.Inherit.IPublicInterface,
                    TypeNames.Inherit.PublicClass,
                    TypeNames.Inherit.PublicImplementIPublicInterfaceClass
                );
        }

        [Fact]
        public void Inherit_should_not_treat_interface_implementation_as_interface_inheritance()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.Inherit)
                .And.Inherit<IPublicInterface>();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types.Should().NotContain(TypeNames.Inherit.PublicImplementIPublicInterfaceClass);
        }

        [Fact]
        public void DoNotInherit_should_not_treat_interface_implementation_as_interface_inheritance()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.Inherit)
                .And.DoNotInherit<IPublicInterface>();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types.Should().Contain(TypeNames.Inherit.PublicImplementIPublicInterfaceClass);
        }
    }
}
