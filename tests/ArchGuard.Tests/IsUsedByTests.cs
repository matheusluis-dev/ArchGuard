namespace ArchGuard.Filters.Tests
{
    using System;
    using System.Linq;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class IsUsedByTests
    {
        [Fact]
        public void IsUsedBy_PublicDependsOnFieldClass()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.IsUsedBy)
                .And.AreUsedBy(TypeNames.IsUsedBy.PublicDependsOnFieldClass);

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.IsUsedBy.PublicClass.ToList());
        }

        [Fact]
        public void IsUsedBy_PublicDependsOnPropertyClass()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.IsUsedBy)
                .And.AreUsedBy(TypeNames.IsUsedBy.PublicDependsOnPropertyClass);

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(TypeNames.IsUsedBy.PublicClass.ToList());
        }
    }
}
