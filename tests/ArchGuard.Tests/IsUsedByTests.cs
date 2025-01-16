namespace ArchGuard.Filters.Tests
{
    using System;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class IsUsedByTests
    {
        [Fact]
        public void IsUsedBy_PublicClass()
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
