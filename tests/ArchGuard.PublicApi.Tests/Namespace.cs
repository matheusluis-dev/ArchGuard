namespace ArchGuard.PublicApi.Tests
{
    using System.Linq;

    public sealed class Namespace
    {
        [Fact]
        public void ArchGuard_must_have_single_namespace()
        {
            // Arrange
            var assembly = typeof(Types).Assembly;

            // Act
            var namespaces = assembly
                .GetTypes()
                .Select(type => type.Namespace)
                .Where(@namespace => @namespace is not null)
                .Distinct(StringComparer.OrdinalIgnoreCase);

            // Assert
            Check.That(namespaces).CountIs(1);
        }
    }
}
