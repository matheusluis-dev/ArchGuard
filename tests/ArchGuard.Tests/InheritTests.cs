namespace ArchGuard.Filters.Tests
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using MockedAssembly.Inherit;
    using NFluent;
    using Shouldly;
    using Xunit;

    // TODO: tests with multiple types as params
    public sealed class InheritTests
    {
        [Fact]
        public void Inherit_interface_with_type_as_argument()
        {
            // Arrange
            var filters = MockedAssembly.Inherit.Types.That.Inherit(typeof(IInterface1));

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check
                .That(types)
                .IsEquivalentTo("ArchGuard.MockedAssembly.Inherit.IInheritInterface1");
        }

        [Fact]
        public void Inherit_interface_with_generic_overload()
        {
            // Arrange
            var filters = MockedAssembly.Inherit.Types.That.Inherit<IInterface1>();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check
                .That(types)
                .IsEquivalentTo("ArchGuard.MockedAssembly.Inherit.IInheritInterface1");
        }

        [Fact]
        public void Inherit_class_with_type_as_argument()
        {
            // Arrange
            var filters = MockedAssembly.Inherit.Types.That.Inherit(typeof(Class1));

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check.That(types).IsEquivalentTo("ArchGuard.MockedAssembly.Inherit.InheritClass1");
        }

        [Fact]
        public void Inherit_class_with_generic_overload()
        {
            // Arrange
            var filters = MockedAssembly.Inherit.Types.That.Inherit<Class1>();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check.That(types).IsEquivalentTo("ArchGuard.MockedAssembly.Inherit.InheritClass1");
        }

        [Fact]
        public void DoNotInherit_interface_with_type_as_argument()
        {
            // Arrange
            var filters = MockedAssembly.Inherit.Types.That.DoNotInherit(typeof(IInterface1));

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check
                .That(types)
                .IsEquivalentTo(
                    "ArchGuard.MockedAssembly.Inherit.Class1",
                    "ArchGuard.MockedAssembly.Inherit.DoNotInheritClass1",
                    "ArchGuard.MockedAssembly.Inherit.IDoNotInheritInterface1",
                    "ArchGuard.MockedAssembly.Inherit.IInterface1",
                    "ArchGuard.MockedAssembly.Inherit.InheritClass1",
                    "ArchGuard.MockedAssembly.Inherit.ImplementIInterface1"
                );
        }

        [Fact]
        public void DoNotInherit_interface_with_generic_overload()
        {
            // Arrange
            var filters = MockedAssembly.Inherit.Types.That.DoNotInherit<IInterface1>();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check
                .That(types)
                .IsEquivalentTo(
                    "ArchGuard.MockedAssembly.Inherit.Class1",
                    "ArchGuard.MockedAssembly.Inherit.DoNotInheritClass1",
                    "ArchGuard.MockedAssembly.Inherit.IDoNotInheritInterface1",
                    "ArchGuard.MockedAssembly.Inherit.IInterface1",
                    "ArchGuard.MockedAssembly.Inherit.InheritClass1",
                    "ArchGuard.MockedAssembly.Inherit.ImplementIInterface1"
                );
        }

        [Fact]
        public void DoNotInherit_class_with_type_as_argument()
        {
            // Arrange
            var filters = MockedAssembly.Inherit.Types.That.DoNotInherit(typeof(Class1));

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check
                .That(types)
                .IsEquivalentTo(
                    "ArchGuard.MockedAssembly.Inherit.Class1",
                    "ArchGuard.MockedAssembly.Inherit.DoNotInheritClass1",
                    "ArchGuard.MockedAssembly.Inherit.IDoNotInheritInterface1",
                    "ArchGuard.MockedAssembly.Inherit.IInterface1",
                    "ArchGuard.MockedAssembly.Inherit.IInheritInterface1",
                    "ArchGuard.MockedAssembly.Inherit.ImplementIInterface1"
                );
        }

        [Fact]
        public void DoNotInherit_class_with_generic_overload()
        {
            // Arrange
            var filters = MockedAssembly.Inherit.Types.That.DoNotInherit<Class1>();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types.ShouldBe(
                [
                    "ArchGuard.MockedAssembly.Inherit.Class1",
                    "ArchGuard.MockedAssembly.Inherit.DoNotInheritClass1",
                    "ArchGuard.MockedAssembly.Inherit.IDoNotInheritInterface1",
                    "ArchGuard.MockedAssembly.Inherit.IInheritInterface1",
                    "ArchGuard.MockedAssembly.Inherit.IInterface1",
                    "ArchGuard.MockedAssembly.Inherit.ImplementIInterface1",
                ]
            );
        }

        [Fact]
        public void Inherit_should_not_treat_interface_implementation_as_interface_inheritance()
        {
            // Arrange
            var filters = MockedAssembly.Inherit.Types.That.Inherit<IInterface1>();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check
                .That(types)
                .Not.Contains("ArchGuard.MockedAssembly.Inherit.ImplementIInterface1");
        }

        [Fact]
        public void DoNotInherit_should_not_treat_interface_implementation_as_interface_inheritance()
        {
            // Arrange
            var filters = MockedAssembly.Inherit.Types.That.DoNotInherit<IInterface1>();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check.That(types).Contains("ArchGuard.MockedAssembly.Inherit.ImplementIInterface1");
        }

        [Fact]
        public void Inherit_generic_type()
        {
            // Arrange
            var filters = MockedAssembly.Inherit.Types.That.Inherit(typeof(GenericParentClass<>));

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types.ShouldBe(
                new List<string> { "ArchGuard.MockedAssembly.Inherit.InheritGenericParentClass" }
            );
        }
    }
}
