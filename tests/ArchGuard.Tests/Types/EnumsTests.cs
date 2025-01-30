namespace ArchGuard.Filters.Tests.Types
{
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using NFluent;
    using Xunit;

    public sealed class EnumsTests
    {
        [Fact]
        public void AreEnums()
        {
            // Arrange
            var filters = MockedAssembly.Enums.Types.That.AreEnums();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            Check
                .That(types)
                .Contains(
                    "ArchGuard.MockedAssembly.Enums.Enum1",
                    "ArchGuard.MockedAssembly.Enums.Enum2",
                    "ArchGuard.MockedAssembly.Enums.Enum3"
                );
        }

        [Fact]
        public void AreNotEnums()
        {
            // Arrange
            var filters = MockedAssembly.Enums.Types.That.AreNotEnums();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            Check
                .That(types)
                .Contains(
                    "ArchGuard.MockedAssembly.Enums.Class",
                    "ArchGuard.MockedAssembly.Enums.IInterface",
                    "ArchGuard.MockedAssembly.Enums.Record",
                    "ArchGuard.MockedAssembly.Enums.RecordStruct",
                    "ArchGuard.MockedAssembly.Enums.Struct"
                );
        }
    }
}
