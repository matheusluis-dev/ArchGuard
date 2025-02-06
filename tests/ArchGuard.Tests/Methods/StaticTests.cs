namespace ArchGuard.Filters.Tests.Methods
{
    using System;
    using System.Linq;
    using NFluent;
    using Xunit;
    using static ArchGuard.Tests.Common.MockedAssembly.Methods;

    public sealed class StaticTests
    {
        [Fact]
        public void AreStatic()
        {
            // Arrange
            var filters = Static.Types.Verify().Methods.That.AreStatic();

            // Act
            var methods = filters.GetMethods().Select(m => m.Name).Order(StringComparer.Ordinal);

            // Assert
            Check.That(methods).IsEquivalentTo("Static");
        }

        [Fact]
        public void AreNotStatic()
        {
            // Arrange
            var filters = Static.Types.Verify().Methods.That.AreNotStatic();

            // Act
            var methods = filters.GetMethods().Select(m => m.Name).Order(StringComparer.Ordinal);

            // Assert
            Check.That(methods).IsEquivalentTo("NonStatic");
        }
    }
}
