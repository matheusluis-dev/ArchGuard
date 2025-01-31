namespace ArchGuard.PublicApi.Tests
{
    using System.Linq;

    public sealed class Assertions
    {
        [Fact]
        public void All_filters_must_have_a_correspondent_assertion()
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
