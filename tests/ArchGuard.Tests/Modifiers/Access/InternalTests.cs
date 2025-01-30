namespace ArchGuard.Filters.Tests.Modifiers.Access
{
    using System;
    using ArchGuard.Tests.Common.Extensions;
    using NFluent;
    using Xunit;
    using static ArchGuard.Tests.Common.MockedAssembly.AccessModifiers;

    public sealed class InternalTests
    {
        [Fact]
        public void AreInternal()
        {
            // Arrange
            var filters = Internal.Types.That.AreInternal();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check
                .That(types)
                .IsEquivalentTo(
                    "ArchGuard.MockedAssembly.AccessModifiers.Internal.InternalClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Internal.InternalParentClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Internal.InternalParentClass+InternalNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Internal.InternalParentClass+ProtectedInternalNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Internal.PublicParentClass+InternalNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Internal.PublicParentClass+ProtectedInternalNestedClass"
                );
        }

        [Fact]
        public void AreNotInternal()
        {
            // Arrange
            var filters = Internal.Types.That.AreNotInternal();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            Check
                .That(types)
                .IsEquivalentTo(
                    "ArchGuard.MockedAssembly.AccessModifiers.Internal.PublicClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Internal.FileClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Internal.PublicParentClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Internal.PublicParentClass+PublicNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Internal.PublicParentClass+ProtectedNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Internal.PublicParentClass+PrivateNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Internal.InternalParentClass+PublicNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Internal.InternalParentClass+ProtectedNestedClass",
                    "ArchGuard.MockedAssembly.AccessModifiers.Internal.InternalParentClass+PrivateNestedClass"
                );
        }
    }
}
