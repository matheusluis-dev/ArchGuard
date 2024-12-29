namespace ArchGuard.Tests
{
    using System;
    using System.Linq;
    using ArchGuard.Library.Types;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.MockedAssembly.Classes.Public;
    using FluentAssertions;
    using Xunit;

    public sealed class NamespacesTests
    {
        [Fact]
        public void Reside_in_namespace()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .ResideInNamespace(Namespaces.ClassesPublic)
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.ClassesPublic);
        }

        [Fact]
        public void Reside_in_namespace_StringComparison_overload()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .ResideInNamespace(
                    Namespaces.ClassesPublic.ToUpperInvariant(),
                    StringComparison.OrdinalIgnoreCase
                )
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.ClassesPublic);
        }

        [Fact]
        public void Not_reside_in_namespace()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;
            var allTypesExceptPublicClasses = TypeNames.Types.Except(
                TypeNames.ClassesPublic,
                StringComparer.Ordinal
            );

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .NotResideInNamespace(Namespaces.ClassesPublic)
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(allTypesExceptPublicClasses);
        }

        [Fact]
        public void Not_reside_in_namespace_StringComparison_overload()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;
            var allTypesExceptPublicClasses = TypeNames.Types.Except(
                TypeNames.ClassesPublic,
                StringComparer.Ordinal
            );

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .NotResideInNamespace(
                    Namespaces.ClassesPublic.ToUpperInvariant(),
                    StringComparison.OrdinalIgnoreCase
                )
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(allTypesExceptPublicClasses);
        }
    }
}
