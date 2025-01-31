namespace ArchGuard.Filters.Tests.AccessModifiers
{
    using System;
    using ArchGuard.Tests.Common.Extensions;
    using NFluent;
    using Xunit;
    using static ArchGuard.Tests.Common.MockedAssembly.AccessModifiers.File;

    public sealed class FileLocalTests
    {
        [Fact]
        public void AreFile()
        {
            // Arrange
            var filters = Types.That.AreFileLocal();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check
                .That(types)
                .IsEquivalentTo(
                    "ArchGuard.MockedAssembly.AccessModifiers.File.FileClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.File.FileParentClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.File.FileParentClass+InternalNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.File.FileParentClass+PrivateNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.File.FileParentClass+ProtectedInternalNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.File.FileParentClass+ProtectedNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.File.FileParentClass+PublicNestedClass"
                );
        }

        [Fact]
        public void AreNotFile()
        {
            // Arrange
            var filters = Types.That.AreNotFileLocal();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check
                .That(types)
                .IsEquivalentTo(
                    "ArchGuard.MockedAssembly.AccessModifiers.File.InternalClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.File.PublicClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.File.PublicParentClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.File.PublicParentClass+InternalNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.File.PublicParentClass+PublicNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.File.PublicParentClass+ProtectedInternalNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.File.PublicParentClass+ProtectedNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.File.PublicParentClass+PrivateNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.File.InternalParentClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.File.InternalParentClass+InternalNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.File.InternalParentClass+PublicNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.File.InternalParentClass+ProtectedInternalNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.File.InternalParentClass+ProtectedNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.File.InternalParentClass+PrivateNestedClass"
                );
        }
    }
}
