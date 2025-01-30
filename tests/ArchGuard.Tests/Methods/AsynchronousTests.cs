namespace ArchGuard.Filters.Tests.Methods
{
    using System;
    using System.Linq;
    using ArchGuard.Tests.Common;
    using NFluent;
    using Xunit;

    public sealed class AsynchronousTests
    {
        [Fact]
        public void AreAsynchronous()
        {
            // Arrange
            var filters = MockedAssembly.Methods.Asynchronous.Types.Methods.That.AreAsynchronous();

            // Act
            var methods = filters
                .GetMethods()
                .Select(m => m.Symbol.Name)
                .Order(StringComparer.Ordinal);

            // Assert
            Check.That(methods).IsEquivalentTo("AsyncMethod");
        }

        [Fact]
        public void AreNotAsynchronous()
        {
            // Arrange
            var filters =
                MockedAssembly.Methods.Asynchronous.Types.Methods.That.AreNotAsynchronous();

            // Act
            var methods = filters
                .GetMethods()
                .Select(m => m.Symbol.Name)
                .Order(StringComparer.Ordinal);

            // Assert
            Check.That(methods).IsEquivalentTo("SyncMethod");
        }
    }
}
