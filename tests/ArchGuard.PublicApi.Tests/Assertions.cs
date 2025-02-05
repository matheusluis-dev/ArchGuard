namespace ArchGuard.PublicApi.Tests
{
    using System.Linq;

    public sealed class Assertions
    {
        [Fact]
        public void All_type_filters_must_have_a_correspondent_assertion()
        {
            // Arrange
            var filterMethods = typeof(ITypeFilterRule).GetMethods();
            var assertionMethods = typeof(ITypeAssertionRule).GetMethods();

            // Act
            var normalizedFilterMethods = filterMethods
                .Select(m =>
                    m.Name.Replace("Are", string.Empty, StringComparison.Ordinal)
                        .Replace("DoNot", "Not", StringComparison.Ordinal)
                )
                .Order(StringComparer.Ordinal);

            var normalizedAssertionMethods = assertionMethods
                .Where(m => !m.Name.Equals("HaveNamePascalCased", StringComparison.Ordinal))
                .Where(m =>
                    !m.Name.Equals("HaveSourceFileNameMatchingTypeName", StringComparison.Ordinal)
                )
                .Where(m =>
                    !m.Name.Equals("HaveSourceFilePathMatchingNamespace", StringComparison.Ordinal)
                )
                .Select(m =>
                    m.Name.Replace("Be", string.Empty, StringComparison.Ordinal)
                        .Replace("NotBe", "Not", StringComparison.Ordinal)
                )
                .Order(StringComparer.Ordinal);

            // Assert
            Check.That(normalizedFilterMethods).IsEquivalentTo(normalizedAssertionMethods);
        }

        [Fact]
        public void All_method_filters_must_have_a_correspondent_assertion()
        {
            // Arrange
            var filterMethods = typeof(IMethodFilterRule).GetMethods();
            var assertionMethods = typeof(IMethodAssertionRule).GetMethods();

            // Act
            var normalizedFilterMethods = filterMethods
                .Select(m =>
                    m.Name.Replace("Are", string.Empty, StringComparison.Ordinal)
                        .Replace("DoNot", "Not", StringComparison.Ordinal)
                )
                .Order(StringComparer.Ordinal);

            var normalizedAssertionMethods = assertionMethods
                .Where(m => !m.Name.Equals("HaveNamePascalCased", StringComparison.Ordinal))
                .Select(m =>
                    m.Name.Replace("Be", string.Empty, StringComparison.Ordinal)
                        .Replace("NotBe", "Not", StringComparison.Ordinal)
                )
                .Order(StringComparer.Ordinal);

            // Assert
            Check.That(normalizedFilterMethods).IsEquivalentTo(normalizedAssertionMethods);
        }

        [Fact]
        public void All_field_filters_must_have_a_correspondent_assertion()
        {
            // Arrange
            var filterFields = typeof(IFieldFilterRule).GetMethods();
            var assertionFields = typeof(IFieldAssertionRule).GetMethods();

            // Act
            var normalizedFilterMethods = filterFields
                .Select(m =>
                    m.Name.Replace("Are", string.Empty, StringComparison.Ordinal)
                        .Replace("DoNot", "Not", StringComparison.Ordinal)
                )
                .Order(StringComparer.Ordinal);

            var normalizedAssertionMethods = assertionFields
                .Where(m => !m.Name.Equals("HaveNamePascalCased", StringComparison.Ordinal))
                .Where(m => !m.Name.Equals("HaveNameCamelCased", StringComparison.Ordinal))
                .Select(m =>
                    m.Name.Replace("Be", string.Empty, StringComparison.Ordinal)
                        .Replace("NotBe", "Not", StringComparison.Ordinal)
                )
                .Order(StringComparer.Ordinal);

            // Assert
            Check.That(normalizedFilterMethods).IsEquivalentTo(normalizedAssertionMethods);
        }
    }
}
