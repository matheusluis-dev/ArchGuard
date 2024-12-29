namespace ArchGuard.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Library.Types;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.MockedAssembly.Classes.Public;
    using FluentAssertions;
    using Xunit;

    public sealed class LogicalOperatorsTests
    {
        [Fact]
        public void That_with_one_filter()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That(t => t.AreClasses())
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.Classes);
        }

        [Fact]
        public void That_nested_And()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;
            var nonPublicClasses = new List<string>
            {
                TypeNames.InternalClass,
                TypeNames.InternalSealedClass,
                TypeNames.InternalStaticClass,
            };

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That(t => t.AreClasses().And().AreNotPublic())
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(nonPublicClasses);
        }

        [Fact]
        public void And()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;
            var nonPublicClasses = new List<string>
            {
                TypeNames.InternalClass,
                TypeNames.InternalSealedClass,
                TypeNames.InternalStaticClass,
            };

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .AreClasses()
                .And()
                .AreNotPublic()
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(nonPublicClasses);
        }

        [Fact]
        public void And_and()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;
            var nonPublicAndSealedClasses = new List<string> { TypeNames.InternalSealedClass };

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .AreClasses()
                .And()
                .AreNotPublic()
                .And()
                .AreSealed()
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(nonPublicAndSealedClasses);
        }

        [Fact]
        public void Or()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;
            var recordsAndInterfaces = new List<string>();
            recordsAndInterfaces.AddRange(TypeNames.Interfaces);
            recordsAndInterfaces.AddRange(TypeNames.Records);

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .AreInterfaces()
                .Or()
                .AreRecords()
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(recordsAndInterfaces);
        }

        [Fact]
        public void And_or()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;
            var publicClassesAndInterfaces = TypeNames.ClassesPublic.Concat(TypeNames.Interfaces);

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .AreClasses()
                .And()
                .ArePublic()
                .Or()
                .AreInterfaces()
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(publicClassesAndInterfaces);
        }

        [Fact]
        public void And_or_and()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;
            var publicClassesAndInternalInterfaces = TypeNames.ClassesPublic.Concat(
                TypeNames.InterfacesInternal
            );

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .AreClasses()
                .And()
                .ArePublic()
                .Or()
                .AreInterfaces()
                .And()
                .AreInternal()
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(publicClassesAndInternalInterfaces);
        }

        [Fact]
        public void And_or_and_or()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;
            var publicClassesAndInternalInterfacesAndRecords = TypeNames
                .ClassesPublic.Concat(TypeNames.InterfacesInternal)
                .Concat(TypeNames.Records);

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .AreClasses()
                .And()
                .ArePublic()
                .Or()
                .AreInterfaces()
                .And()
                .AreInternal()
                .Or()
                .AreRecords()
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(publicClassesAndInternalInterfacesAndRecords);
        }

        [Fact]
        public void And_grouped()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;
            var nonPublicAndSealedClasses = new List<string> { TypeNames.InternalSealedClass };

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .AreClasses()
                .And(a => a.AreNotPublic().And().AreSealed())
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(nonPublicAndSealedClasses);
        }

        [Fact]
        public void And_double_grouped()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;
            var nonPublicAndSealedClasses = new List<string> { TypeNames.InternalSealedClass };

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .AreClasses()
                .And(a => a.AreNotPublic().And(b => b.AreSealed()))
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(nonPublicAndSealedClasses);
        }

        [Fact]
        public void Or_grouped()
        {
            // Arrange
            var assembly = typeof(PublicClass).Assembly;
            var publicClassesAndInternalInterfaces = TypeNames.ClassesPublic.Concat(
                TypeNames.InterfacesInternal
            );

            // Act
            var types = Types
                .FromAssembly(assembly)
                .That()
                .AreClasses()
                .And()
                .ArePublic()
                .Or(o => o.AreInterfaces().And().AreInternal())
                .GetTypes()
                .GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(publicClassesAndInternalInterfaces);
        }
    }
}
