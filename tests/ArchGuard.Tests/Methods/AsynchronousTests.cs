namespace ArchGuard.Filters.Tests.Methods
{
    using System;
    using System.Linq;
    using NFluent;
    using Xunit;
    using static ArchGuard.Tests.Common.MockedAssembly.Methods;

    public sealed class AsynchronousTests
    {
        [Fact]
        public void AreAsynchronous()
        {
            // Arrange
            var filters = Asynchronous.Types.Verify().Methods.That.AreAsynchronous();

            // Act
            var methods = filters.GetMethods().Select(m => m.Name).Order(StringComparer.Ordinal);

            // Assert
            Check.That(methods).IsEquivalentTo("AsyncMethod");
        }

        [Fact]
        public void AreNotAsynchronous()
        {
            // Arrange
            var filters = Asynchronous.Types.Verify().Methods.That.AreNotAsynchronous();

            // Act
            var methods = filters.GetMethods().Select(m => m.Name).Order(StringComparer.Ordinal);

            // Assert
            Check.That(methods).IsEquivalentTo("SyncMethod");
        }
    }
}
