namespace ArchGuard.Filters.Tests.Types
{
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using NFluent;
    using Xunit;

    public sealed class StructsTests
    {
        [Fact]
        public void AreStructs()
        {
            // Arrange
            var filters = MockedAssembly.Structs.Types.That.AreStructs();

            // Act
            var types = filters.GetTypes().GetFullNames();

            Check
                .That(types)
                .IsEquivalentTo(
                    "ArchGuard.MockedAssembly.Structs.Struct1",
                    "ArchGuard.MockedAssembly.Structs.Struct2",
                    "ArchGuard.MockedAssembly.Structs.Struct3"
                );
        }

        [Fact]
        public void AreNotStructs()
        {
            // Arrange
            var filters = MockedAssembly.Structs.Types.That.AreNotStructs();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            Check
                .That(types)
                .IsEquivalentTo(
                    "ArchGuard.MockedAssembly.Structs.Class",
                    "ArchGuard.MockedAssembly.Structs.Enum",
                    "ArchGuard.MockedAssembly.Structs.IInterface",
                    "ArchGuard.MockedAssembly.Structs.Record",
                    "ArchGuard.MockedAssembly.Structs.RecordStruct"
                );
        }
    }
}
