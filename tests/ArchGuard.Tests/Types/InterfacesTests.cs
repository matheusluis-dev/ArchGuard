namespace ArchGuard.Filters.Tests.Types
{
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using NFluent;
    using Xunit;

    public sealed class InterfacesTests
    {
        [Fact]
        public void AreInterfaces()
        {
            // Arrange
            var filters = MockedAssembly.Interfaces.Types.That.AreInterfaces();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            Check
                .That(types)
                .IsEquivalentTo(
                    "ArchGuard.MockedAssembly.Interfaces.IInterface1",
                    "ArchGuard.MockedAssembly.Interfaces.IInterface2",
                    "ArchGuard.MockedAssembly.Interfaces.IInterface3"
                );
        }

        [Fact]
        public void AreNotInterfaces()
        {
            // Arrange
            var filters = MockedAssembly.Interfaces.Types.That.AreNotInterfaces();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            Check
                .That(types)
                .IsEquivalentTo(
                    "ArchGuard.MockedAssembly.Interfaces.Class",
                    "ArchGuard.MockedAssembly.Interfaces.Enum",
                    "ArchGuard.MockedAssembly.Interfaces.Record",
                    "ArchGuard.MockedAssembly.Interfaces.RecordStruct",
                    "ArchGuard.MockedAssembly.Interfaces.Struct"
                );
        }
    }
}
