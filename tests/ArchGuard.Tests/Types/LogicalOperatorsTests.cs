namespace ArchGuard.Tests.Types
{
    using System.Collections.Generic;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class LogicalOperatorsTests
    {
        [Fact]
        public void That_with_one_filter()
        {
            // Arrange
            var expected = new List<string>
            {
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
                TypeNames.PublicClass,
                TypeNames.PublicParentClass,
                TypeNames.PublicParentClass_InternalNestedClass,
                TypeNames.PublicParentClass_PrivateNestedClass,
                TypeNames.PublicParentClass_PublicNestedClass,
                TypeNames.PublicPartialClass,
                TypeNames.PublicSealedClass,
                TypeNames.PublicStaticClass,
            };
            var filters = TypesFromMockedAssembly.All.That(t => t.AreClasses());

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void That_nested_And()
        {
            // Arrange
            var expected = new List<string>
            {
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
            };
            var filters = TypesFromMockedAssembly.All.That(t =>
                t.AreClasses().And().AreNotPublic()
            );

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void And()
        {
            // Arrange
            var expected = new List<string>
            {
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
            };
            var filters = TypesFromMockedAssembly.All.That().AreClasses().And().AreNotPublic();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void And_and()
        {
            // Arrange
            var expected = new List<string>
            {
#if NET7_0_OR_GREATER
                TypeNames.FileSealedClass,
#endif
                TypeNames.InternalSealedClass,
            };
            var filters = TypesFromMockedAssembly
                .All.That()
                .AreClasses()
                .And()
                .AreNotPublic()
                .And()
                .AreSealed();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Or()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.IInternalInterface,
                TypeNames.IPublicInterface,
                TypeNames.InternalEnum,
                TypeNames.PublicEnum,
            };
            var filters = TypesFromMockedAssembly.All.That().AreInterfaces().Or().AreEnums();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void And_or()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.PublicClass,
                TypeNames.PublicParentClass,
                TypeNames.PublicParentClass_PublicNestedClass,
                TypeNames.PublicPartialClass,
                TypeNames.PublicSealedClass,
                TypeNames.PublicStaticClass,
                TypeNames.IInternalInterface,
                TypeNames.IPublicInterface,
            };
            var filters = TypesFromMockedAssembly
                .All.That()
                .AreClasses()
                .And()
                .ArePublic()
                .Or()
                .AreInterfaces();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void And_or_and()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.PublicClass,
                TypeNames.PublicParentClass,
                TypeNames.PublicParentClass_PublicNestedClass,
                TypeNames.PublicPartialClass,
                TypeNames.PublicSealedClass,
                TypeNames.PublicStaticClass,
                TypeNames.IInternalInterface,
            };
            var filters = TypesFromMockedAssembly
                .All.That()
                .AreClasses()
                .And()
                .ArePublic()
                .Or()
                .AreInterfaces()
                .And()
                .AreInternal();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void And_or_and_or()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.PublicClass,
                TypeNames.PublicParentClass,
                TypeNames.PublicParentClass_PublicNestedClass,
                TypeNames.PublicPartialClass,
                TypeNames.PublicSealedClass,
                TypeNames.PublicStaticClass,
                TypeNames.IInternalInterface,
                TypeNames.InternalEnum,
                TypeNames.PublicEnum,
            };
            var filters = TypesFromMockedAssembly
                .All.That()
                .AreClasses()
                .And()
                .ArePublic()
                .Or()
                .AreInterfaces()
                .And()
                .AreInternal()
                .Or()
                .AreEnums();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void And_grouped()
        {
            // Arrange
            var expected = new List<string>
            {
#if NET7_0_OR_GREATER
                TypeNames.FileSealedClass,
#endif
                TypeNames.InternalSealedClass,
            };
            var filters = TypesFromMockedAssembly
                .All.That()
                .AreClasses()
                .And(a => a.AreNotPublic().And().AreSealed());

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void And_double_grouped()
        {
            // Arrange
            var expected = new List<string>
            {
#if NET7_0_OR_GREATER
                TypeNames.FileSealedClass,
#endif
                TypeNames.InternalSealedClass,
            };
            var filters = TypesFromMockedAssembly
                .All.That()
                .AreClasses()
                .And(a => a.AreNotPublic().And(b => b.AreSealed()));

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Or_grouped()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.PublicClass,
                TypeNames.PublicParentClass,
                TypeNames.PublicParentClass_PublicNestedClass,
                TypeNames.PublicPartialClass,
                TypeNames.PublicSealedClass,
                TypeNames.PublicStaticClass,
                TypeNames.IInternalInterface,
            };
            var filters = TypesFromMockedAssembly
                .All.That()
                .AreClasses()
                .And()
                .ArePublic()
                .Or(o => o.AreInterfaces().And().AreInternal());

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }
    }
}
