namespace ArchGuard.Filters.Tests.Types
{
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using NFluent;
    using Xunit;

    public sealed class ClassesTests
    {
        [Fact]
        public void AreClasses()
        {
            // Arrange
            var filters = MockedAssembly.Classes.Types.That.AreClasses();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            Check
                .That(types)
                .Contains(
                    "ArchGuard.MockedAssembly.Classes.Class1",
                    "ArchGuard.MockedAssembly.Classes.Class2",
                    "ArchGuard.MockedAssembly.Classes.Class3"
                );
        }

        [Fact]
        public void AreNotClasses()
        {
            // Arrange
            var filters = MockedAssembly.Classes.Types.That.AreNotClasses();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            Check
                .That(types)
                .Contains(
                    "ArchGuard.MockedAssembly.Classes.Enum",
                    "ArchGuard.MockedAssembly.Classes.IInterface",
                    "ArchGuard.MockedAssembly.Classes.Record",
                    "ArchGuard.MockedAssembly.Classes.RecordStruct",
                    "ArchGuard.MockedAssembly.Classes.Struct"
                );
        }
    }
}
