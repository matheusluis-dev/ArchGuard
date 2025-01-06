namespace ArchGuard.Filters.Tests
{
    using System.Collections.Generic;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using ArchGuard.Tests.MockedAssembly.Classes.Public;
    using FluentAssertions;
    using Xunit;

    public sealed class AreOfTypeTests
    {
        [Fact]
        public void Are_of_type_generic_parameter()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.AreOfType<PublicClass>();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(new List<string> { TypeNames.PublicClass });
        }

        [Fact]
        public void Are_of_type_explicit_parameter()
        {
            // Arrange
#pragma warning disable CA2263 // Prefer generic overload when type is known
            var filters = TypesFromMockedAssembly.All.That.AreOfType(typeof(PublicClass));
#pragma warning restore CA2263 // Prefer generic overload when type is known

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(new List<string> { TypeNames.PublicClass });
        }
    }
}
