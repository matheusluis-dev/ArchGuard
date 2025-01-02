namespace ArchGuard.Tests.Api
{
    using System;
    using System.Linq;
    using System.Reflection;
    using ArchGuard.Library.Type.Filters;
    using ArchGuard.Library.Type.Filters.Conditions.Interfaces;
    using ArchGuard.Tests.Common.Extensions;
    using FluentAssertions;
    using Xunit;

    public sealed class DotNet5OrGreaterTests
    {
        private readonly Func<MethodInfo, bool> _endsWithRecordPredicate = method =>
            method.Name.EndsWith("Records", StringComparison.Ordinal)
            || method.Name.EndsWith("Record", StringComparison.Ordinal);

#if NET5_0_OR_GREATER
        [Theory]
        [InlineData(typeof(ITypesFilterConditions))]
        [InlineData(typeof(TypesFilter))]
        public void Record_related_filters_should_be_visible_when_DotNet_version_5_0_or_greater(
            Type type
        )
        {
            // Act
            var methods = type.GetMethods().Where(_endsWithRecordPredicate);

            // Assert
            methods.Should().HaveCount(2);
        }

        [Fact]
        public void Record_extensions_should_be_visible_when_DotNet_version_5_0_or_greater()
        {
            // Arrange
            var assembly = typeof(TypesFilter).Assembly;
            var type = typeof(Type);

            // Act
            var methods = type.GetExtensionMethods(assembly).Where(_endsWithRecordPredicate);

            // Assert
            methods.Should().HaveCount(2);
        }
#else
        [Theory]
        [InlineData(typeof(ITypesFilterConditions))]
        [InlineData(typeof(TypesFilter))]
        public void Record_related_filters_should_not_be_visible_when_DotNet_version_5_0_or_greater(
            Type type
        )
        {
            // Act
            var methods = type.GetMethods().Where(_endsWithRecordPredicate);

            // Assert
            methods.Should().BeEmpty();
        }

        [Fact]
        public void Record_extensions_should_not_be_visible_when_DotNet_version_5_0_or_greater()
        {
            // Arrange
            var assembly = typeof(TypesFilter).Assembly;
            var type = typeof(Type);

            // Act
            var methods = type.GetExtensionMethods(assembly).Where(_endsWithRecordPredicate);

            // Assert
            methods.Should().BeEmpty();
        }
#endif
    }
}
