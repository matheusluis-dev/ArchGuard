namespace ArchGuard.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Library.Types;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using ArchGuard.Tests.Common.Types.Builder;
    using ArchGuard.Tests.MockedAssembly.Classes.Public;
    using FluentAssertions;
    using Xunit;

    public sealed class NamespacesTests
    {
        [Fact]
        public void Reside_in_namespace()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNamesRefactorStatic.PublicClass,
                TypeNamesRefactorStatic.PublicPartialClass,
                TypeNamesRefactorStatic.PublicSealedClass,
                TypeNamesRefactorStatic.PublicStaticClass,
            };
            var filters = TypesFromMockedAssembly
                .All.That()
                .ResideInNamespace(Namespaces.ClassesPublic);

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Reside_in_namespace_StringComparison_overload()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNamesRefactorStatic.PublicClass,
                TypeNamesRefactorStatic.PublicPartialClass,
                TypeNamesRefactorStatic.PublicSealedClass,
                TypeNamesRefactorStatic.PublicStaticClass,
            };
            var filters = TypesFromMockedAssembly
                .All.That()
                .ResideInNamespace(
                    Namespaces.ClassesPublic.ToUpperInvariant(),
                    StringComparison.OrdinalIgnoreCase
                );

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Not_reside_in_namespace()
        {
            // Arrange
            var expected = TypeNamesFromMockedAssembly
                .That()
                .NotResideInNamespace(Namespaces.ClassesPublic)
                .GetTypeNames();
            var filters = TypesFromMockedAssembly
                .All.That()
                .NotResideInNamespace(Namespaces.ClassesPublic);

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Not_reside_in_namespace_StringComparison_overload()
        {
            // Arrange
            var expected = TypeNamesFromMockedAssembly
                .That()
                .NotResideInNamespace(Namespaces.ClassesPublic)
                .GetTypeNames();
            var filters = TypesFromMockedAssembly
                .All.That()
                .NotResideInNamespace(
                    Namespaces.ClassesPublic.ToUpperInvariant(),
                    StringComparison.OrdinalIgnoreCase
                );

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }
    }
}
