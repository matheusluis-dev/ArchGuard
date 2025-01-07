namespace ArchGuard.Filters.Tests.Names
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class HaveNameTests
    {
        [Fact]
        public void Have_name()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.HaveName("PublicClass");

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(new List<string> { TypeNames.PublicClass });
        }

        [Fact]
        public void Have_name_with_StringComparison()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.HaveName("publicclass");

            // Act
            var types = filters.GetTypes(StringComparison.OrdinalIgnoreCase).GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(new List<string> { TypeNames.PublicClass });
        }

        [Fact]
        public void Have_name_with_params()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.HaveName("PublicClass", "InternalClass");

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.PublicClass, TypeNames.InternalClass);
        }

        [Fact]
        public void Have_name_with_params_and_StringComparison()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.HaveName("publicclass", "INTERNALCLASS");

            // Act
            var types = filters.GetTypes(StringComparison.OrdinalIgnoreCase).GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.PublicClass, TypeNames.InternalClass);
        }

        [Fact]
        public void Have_full_name()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.HaveFullName(TypeNames.PublicClass);

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(new List<string> { TypeNames.PublicClass });
        }

        [Fact]
        public void Have_full_name_with_StringComparison()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.HaveFullName(
                TypeNames.PublicClass.ToUpperInvariant()
            );

            // Act
            var types = filters.GetTypes(StringComparison.OrdinalIgnoreCase).GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(new List<string> { TypeNames.PublicClass });
        }

        [Fact]
        public void Have_full_name_with_params()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.HaveFullName(
                TypeNames.PublicClass,
                TypeNames.InternalClass
            );

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.PublicClass, TypeNames.InternalClass);
        }

        [Fact]
        public void Have_full_name_with_params_and_StringComparison()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.HaveFullName(
                TypeNames.PublicClass.ToUpperInvariant(),
                TypeNames.InternalClass.ToUpperInvariant()
            );

            // Act
            var types = filters.GetTypes(StringComparison.OrdinalIgnoreCase).GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.PublicClass, TypeNames.InternalClass);
        }
    }
}
