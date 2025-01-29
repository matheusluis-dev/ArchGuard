namespace ArchGuard.PublicApi.Tests.Version
{
    using System;
    using System.Linq;
    using System.Reflection;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuardType.Filters;
    using FluentAssertions;
    using Xunit;

    public sealed class DotNet7OrGreaterTests
    {
        private readonly Func<MethodInfo, bool> _endsWithFileScopedPredicate = method =>
            method.Name.EndsWith("FileScoped", StringComparison.Ordinal);

#if NET7_0_OR_GREATER
        [Theory]
        [InlineData(typeof(ITypeDefinitionFilterRule))]
        [InlineData(typeof(TypeDefinitionFilter))]
        public void File_scoped_related_filters_should_be_visible_when_DotNet_version_7_0_or_greater(
            Type type
        )
        {
            // Act
            var methods = type.GetMethods().Where(_endsWithFileScopedPredicate);

            // Assert
            methods.Should().HaveCount(2);
        }

        [Fact]
        public void File_scoped_extensions_should_be_visible_when_DotNet_version_7_0_or_greater()
        {
            // Arrange
            var assembly = typeof(TypeDefinitionFilter).Assembly;
            var type = typeof(Type);

            // Act
            var fileScopedMethods = type.GetExtensionMethods(assembly)
                .Where(_endsWithFileScopedPredicate);

            // Assert
            fileScopedMethods.Should().HaveCount(2);
        }
#else
        [Theory]
        [InlineData(typeof(ITypesFilterConditions))]
        [InlineData(typeof(TypesFilter))]
        public void File_scoped_related_filters_should_not_be_visible_when_DotNet_version_lesser_than_7_0(
            Type type
        )
        {
            // Act
            var methods = type.GetMethods().Where(_endsWithFileScopedPredicate);

            // Assert
            methods.Should().BeEmpty();
        }

        [Fact]
        public void File_scoped_extensions_should_not_be_visible_when_DotNet_version_7_0_or_greater()
        {
            // Arrange
            var assembly = typeof(TypesFilter).Assembly;
            var type = typeof(Type);

            // Act
            var fileScopedMethods = type.GetExtensionMethods(assembly)
                .Where(_endsWithFileScopedPredicate);

            // Assert
            fileScopedMethods.Should().BeEmpty();
        }
#endif
    }
}
