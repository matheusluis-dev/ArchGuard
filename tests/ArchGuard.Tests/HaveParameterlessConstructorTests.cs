namespace ArchGuard.Filters.Tests
{
    using System;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class HaveParameterlessConstructorTests
    {
        [Fact]
        public void HaveParameterlessConstructor()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(
                    ArchGuard.Tests.Common.Namespaces.HaveParameterlessConstructor
                )
                .And.HaveParameterlessConstructor();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.HaveParameterlessConstructor.PublicOneParameterlessConstructorClass,
                    TypeNames.HaveParameterlessConstructor.PublicOnlyParameterlessConstructorClass
                );
        }

        [Fact]
        public void DoNotHaveParameterlessConstructor()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(
                    ArchGuard.Tests.Common.Namespaces.HaveParameterlessConstructor
                )
                .And.DoNotHaveParameterlessConstructor();

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.HaveParameterlessConstructor.PublicWithoutParameterlessConstructorClass.ToList()
                );
        }
    }
}
