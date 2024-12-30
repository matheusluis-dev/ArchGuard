namespace ArchGuard.Tests
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types.Builder;
    using FluentAssertions;
    using Xunit;

    public sealed class NamesTests
    {
        [Fact]
        public void Name_starting()
        {
            // Arrange
            var prefix = "PublicSealed";

            var expected = TypeNamesFromMockedAssembly
                .That()
                .HaveNameStartingWith(prefix)
                .GetTypeNames();
            var filters = TypesFromMockedAssembly.All.That().HaveNameStartingWith(prefix);

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Name_starting_with_StringComparison()
        {
            // Arrange
            var prefix = "PublicSealed";

            var expected = TypeNamesFromMockedAssembly
                .That()
                .HaveNameStartingWith(prefix)
                .GetTypeNames();
            var filters = TypesFromMockedAssembly
                .All.That()
                .HaveNameStartingWith(
                    prefix.ToUpperInvariant(),
                    StringComparison.OrdinalIgnoreCase
                );

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Name_ending()
        {
            // Arrange
            var suffix = "Class";

            var expected = TypeNamesFromMockedAssembly
                .That()
                .HaveNameEndingWith(suffix)
                .GetTypeNames();
            var filters = TypesFromMockedAssembly.All.That().HaveNameEndingWith(suffix);

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Name_ending_with_StringComparison()
        {
            // Arrange
            var suffix = "Class";

            var expected = TypeNamesFromMockedAssembly
                .That()
                .HaveNameEndingWith(suffix)
                .GetTypeNames();
            var filters = TypesFromMockedAssembly
                .All.That()
                .HaveNameEndingWith(suffix.ToUpperInvariant(), StringComparison.OrdinalIgnoreCase);

            // Act
            var types = filters.GetTypes().GetFullNamesOrdered();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }
    }
}
