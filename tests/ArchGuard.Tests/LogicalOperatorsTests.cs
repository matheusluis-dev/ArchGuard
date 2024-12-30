namespace ArchGuard.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Library.Types;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using ArchGuard.Tests.MockedAssembly.Classes.Public;
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
                TypeNames.InternalClass,
                TypeNames.InternalPartialClass,
                TypeNames.InternalSealedClass,
                TypeNames.InternalStaticClass,
                TypeNames.PublicClass,
                TypeNames.PublicPartialClass,
                TypeNames.PublicSealedClass,
                TypeNames.PublicStaticClass,
            };
            var filters = TypesFromMockedAssembly.All.That(t => t.AreClasses());

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void That_nested_And()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.InternalClass,
                TypeNames.InternalPartialClass,
                TypeNames.InternalSealedClass,
                TypeNames.InternalStaticClass,
            };
            var filters = TypesFromMockedAssembly.All.That(t =>
                t.AreClasses().And().AreNotPublic()
            );

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void And()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.InternalClass,
                TypeNames.InternalPartialClass,
                TypeNames.InternalSealedClass,
                TypeNames.InternalStaticClass,
            };
            var filters = TypesFromMockedAssembly.All.That().AreClasses().And().AreNotPublic();

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void And_and()
        {
            // Arrange
            var expected = new List<string> { TypeNames.InternalSealedClass };
            var filters = TypesFromMockedAssembly
                .All.That()
                .AreClasses()
                .And()
                .AreNotPublic()
                .And()
                .AreSealed();

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

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
            var types = filters.GetTypes().GetFullNamesOrdered();

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
            var types = filters.GetTypes().GetFullNamesOrdered();

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
            var types = filters.GetTypes().GetFullNamesOrdered();

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
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void And_grouped()
        {
            // Arrange
            var expected = new List<string> { TypeNames.InternalSealedClass };
            var filters = TypesFromMockedAssembly
                .All.That()
                .AreClasses()
                .And(a => a.AreNotPublic().And().AreSealed());

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void And_double_grouped()
        {
            // Arrange
            var expected = new List<string> { TypeNames.InternalSealedClass };
            var filters = TypesFromMockedAssembly
                .All.That()
                .AreClasses()
                .And(a => a.AreNotPublic().And(b => b.AreSealed()));

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

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
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }
    }
}
