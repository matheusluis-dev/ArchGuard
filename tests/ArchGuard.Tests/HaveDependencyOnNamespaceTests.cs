namespace ArchGuard.Filters.Tests
{
    using System;
    using ArchGuard.Tests.Common.Extensions;
    using NFluent;
    using Xunit;
    using static ArchGuard.Tests.Common.MockedAssembly;

    public sealed class HaveDependencyOnNamespaceTests
    {
        [Fact]
        public void HaveDependencyOn_immediate_dependency()
        {
            // Arrange
            var filters = HaveDependencyOnNamespace.Types.That.HaveDependencyOnNamespace(
                "ArchGuard.MockedAssembly.HaveDependencyOnNamespace.NamespaceB"
            );

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check.That(types).Contains("ArchGuard.MockedAssembly.HaveDependencyOnNamespace.NamespaceA.Class");
        }

        [Fact]
        public void HaveDependencyOn_indirect_dependency()
        {
            // Arrange
            var filters = HaveDependencyOnNamespace.Types.That.HaveDependencyOnNamespace(
                "ArchGuard.MockedAssembly.HaveDependencyOnNamespace.NamespaceB"
            );

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check.That(types).Contains("ArchGuard.MockedAssembly.HaveDependencyOnNamespace.NamespaceC.Class");
        }

        [Fact]
        public void HaveDependencyOn_should_not_recognize_dependencies_on_same_namespace_as_dependencies()
        {
            // Arrange
            var filters = HaveDependencyOnNamespace.Types.That.HaveDependencyOnNamespace(
                "ArchGuard.MockedAssembly.HaveDependencyOnNamespace.NamespaceB"
            );

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check
                .That(types)
                .Not.Contains(
                    "ArchGuard.MockedAssembly.HaveDependencyOnNamespace.NamespaceB.Class",
                    "ArchGuard.MockedAssembly.HaveDependencyOnNamespace.NamespaceB.AnotherClass"
                );
        }

        [Fact]
        public void HaveDependencyOn_should_treat_sub_namespaces_as_same_namespace()
        {
            // Arrange
            var filters = HaveDependencyOnNamespace.Types.That.HaveDependencyOnNamespace(
                "ArchGuard.MockedAssembly.HaveDependencyOnNamespace.NamespaceB"
            );

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check
                .That(types)
                .Not.Contains("ArchGuard.MockedAssembly.HaveDependencyOnNamespace.NamespaceB.SubNamespace.SubClass");
        }

        [Fact]
        public void DoNotHaveDependencyOn_should_not_recognize_dependencies_on_same_namespace_as_dependencies()
        {
            // Arrange
            var filters = HaveDependencyOnNamespace.Types.That.DoNotHaveDependencyOnNamespace(
                "ArchGuard.MockedAssembly.HaveDependencyOnNamespace.NamespaceB"
            );

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check
                .That(types)
                .Contains(
                    "ArchGuard.MockedAssembly.HaveDependencyOnNamespace.NamespaceB.Class",
                    "ArchGuard.MockedAssembly.HaveDependencyOnNamespace.NamespaceB.AnotherClass"
                );
        }

        [Fact]
        public void DoNotHaveDependencyOn_should_treat_sub_namespaces_as_same_namespace()
        {
            // Arrange
            var filters = HaveDependencyOnNamespace.Types.That.DoNotHaveDependencyOnNamespace(
                "ArchGuard.MockedAssembly.HaveDependencyOnNamespace.NamespaceB"
            );

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check
                .That(types)
                .Contains("ArchGuard.MockedAssembly.HaveDependencyOnNamespace.NamespaceB.SubNamespace.SubClass");
        }
    }
}
