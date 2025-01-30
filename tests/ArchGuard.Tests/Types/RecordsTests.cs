namespace ArchGuard.Filters.Tests.Types
{
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using NFluent;
    using Xunit;

    public sealed class RecordsTests
    {
        [Fact]
        public void AreRecords()
        {
            // Arrange
            var filters = MockedAssembly.Records.Types.That.AreRecords();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            //Check
            //    .That(types)
            //    .Contains(
            //        "ArchGuard.MockedAssembly.Records.Record1",
            //        "ArchGuard.MockedAssembly.Records.Record2",
            //        "ArchGuard.MockedAssembly.Records.Record3"
            //    );
            Check
                .That(types)
                .IsEquivalentTo(
                    "ArchGuard.MockedAssembly.Records.Record1",
                    "ArchGuard.MockedAssembly.Records.Record2",
                    "ArchGuard.MockedAssembly.Records.Record3"
                );
        }

        [Fact]
        public void AreNotRecords()
        {
            // Arrange
            var filters = MockedAssembly.Records.Types.That.AreNotRecords();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            Check
                .That(types)
                .IsEquivalentTo(
                    "ArchGuard.MockedAssembly.Records.Class",
                    "ArchGuard.MockedAssembly.Records.Enum",
                    "ArchGuard.MockedAssembly.Records.IInterface",
                    "ArchGuard.MockedAssembly.Records.RecordStruct",
                    "ArchGuard.MockedAssembly.Records.Struct"
                );
        }
    }
}
