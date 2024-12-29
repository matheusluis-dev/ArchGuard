namespace ArchGuard.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Library.Types;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using ArchGuard.Tests.MockedAssembly.Classes.Public;
    using FluentAssertions;
    using Xunit;

    public sealed class ClassesTests
    {
        [Fact]
        public void Get_classes()
        {
            // Arrange
            var expected = TypeNamesRefactorStatic.Classes;
            var filters = TypesFromMockedAssembly.All.That().AreClasses();

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_non_class_types()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;
            var nonClassTypes = TypeNames.Types.Except(TypeNames.Classes, StringComparer.Ordinal);

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .AreNotClasses()
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(nonClassTypes);
        }

        [Fact]
        public void Get_public_classes()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .AreClasses()
                .And()
                .ArePublic()
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.ClassesPublic);
        }

        [Fact]
        public void Get_internal_classes()
        {
            // Arrange
            var expected = TypeNamesRefactorStatic.InternalClasses;
            var filters = TypesFromMockedAssembly.All.That().AreClasses().And().AreInternal();

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_partial_classes()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .AreClasses()
                .And()
                .ArePartial()
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(new List<string> { TypeNames.PublicPartialClass });
        }

        [Fact]
        public void Get_sealed_classes()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;
            var sealedClasses = new List<string>
            {
                TypeNames.InternalSealedClass,
                TypeNames.PublicSealedClass,
#if NET5_0_OR_GREATER
                "Microsoft.CodeAnalysis.EmbeddedAttribute",
                "System.Runtime.CompilerServices.NullableAttribute",
                "System.Runtime.CompilerServices.NullableContextAttribute",
#endif
            };

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .AreClasses()
                .And()
                .AreSealed()
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(sealedClasses);
        }
    }
}
