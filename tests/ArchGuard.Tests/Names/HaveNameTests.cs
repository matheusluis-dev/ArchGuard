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
            var filters = TypesFromMockedAssembly.All.That.HaveName(
                "PublicClass",
                StringComparison.Ordinal
            );

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(new List<string> { TypeNames.PublicClass });
        }

        [Fact]
        public void Have_full_name()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.HaveFullName(
                TypeNames.PublicClass,
                StringComparison.Ordinal
            );

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(new List<string> { TypeNames.PublicClass });
        }
    }
}
