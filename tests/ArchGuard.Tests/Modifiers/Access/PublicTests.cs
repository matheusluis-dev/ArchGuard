namespace ArchGuard.Filters.Tests.Modifiers.Access
{
    using System;
    using ArchGuard.Tests.Common.Extensions;
    using NFluent;
    using Xunit;
    using static ArchGuard.Tests.Common.MockedAssembly.AccessModifiers;

    public sealed class PublicTests
    {
        [Fact]
        public void ArePublic()
        {
            // Arrange
            var filters = Public.Types.That.ArePublic();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check
                .That(types)
                .IsEquivalentTo(
                    "ArchGuard.MockedAssembly.AccessModifiers.Public.PublicClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Public.PublicParentClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Public.PublicParentClass+PublicNestedClass"
                );
        }

        [Fact]
        public void AreNotPublic()
        {
            // Arrange
            var filters = Public.Types.That.AreNotPublic();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check
                .That(types)
                .IsEquivalentTo(
                    "ArchGuard.MockedAssembly.AccessModifiers.Public.FileClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Public.InternalClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Public.InternalParentClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Public.InternalParentClass+PublicNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Public.InternalParentClass+InternalNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Public.InternalParentClass+ProtectedNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Public.InternalParentClass+PrivateNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Public.PublicParentClass+InternalNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Public.PublicParentClass+ProtectedNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Public.PublicParentClass+PrivateNestedClass"
                );
        }
    }
}
