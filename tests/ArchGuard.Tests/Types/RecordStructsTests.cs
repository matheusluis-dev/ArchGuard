namespace ArchGuard.Filters.Tests.Types
{
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using NFluent;
    using Xunit;

    public sealed class RecordStructsTests
    {
        [Fact]
        public void AreRecordStructs()
        {
            // Arrange
            var filters = MockedAssembly.RecordStructs.Types.That.AreRecordStructs();

            // Act
            var types = filters.GetTypes().GetFullNames();

            Check
                .That(types)
                .IsEquivalentTo(
                    "ArchGuard.MockedAssembly.RecordStructs.RecordStruct1",
                    "ArchGuard.MockedAssembly.RecordStructs.RecordStruct2",
                    "ArchGuard.MockedAssembly.RecordStructs.RecordStruct3"
                );
        }

        [Fact]
        public void AreNotRecordStructs()
        {
            // Arrange
            var filters = MockedAssembly.RecordStructs.Types.That.AreNotRecordStructs();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            Check
                .That(types)
                .IsEquivalentTo(
                    "ArchGuard.MockedAssembly.RecordStructs.Class",
                    "ArchGuard.MockedAssembly.RecordStructs.Enum",
                    "ArchGuard.MockedAssembly.RecordStructs.IInterface",
                    "ArchGuard.MockedAssembly.RecordStructs.Record",
                    "ArchGuard.MockedAssembly.RecordStructs.Struct"
                );
        }
    }
}
