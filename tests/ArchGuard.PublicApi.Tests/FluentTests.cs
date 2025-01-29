namespace ArchGuard.PublicApi.Tests
{
    using ArchGuard.Library.Type.Filters;
    using ArchGuard.Tests.Common;
    using ArchGuard.Type.Filters.Sequences;
    using FluentAssertions;
    using Xunit;

    public sealed class FluentTests
    {
        [Fact]
        public void And_method_should_return_ITypesFilterConditions_instance()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All;

            // Act
            var conditions = filters.That.AreClasses().And;

            // Assert
            conditions.Should().BeAssignableTo<ITypeDefinitionFilterRule>();
        }

        [Fact]
        public void And_method_should_return_ITypesFilterPostCondition_instance_when_has_predicate()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All;

            // Act
            var conditions = filters.That.AreClasses().And(a => a.ArePublic());

            // Assert
            conditions.Should().BeAssignableTo<ITypeDefinitionFilterSequence>();
        }

        [Fact]
        public void Or_method_should_return_ITypesFilterConditions_instance()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All;

            // Act
            var conditions = filters.That.AreClasses().Or;

            // Assert
            conditions.Should().BeAssignableTo<ITypeDefinitionFilterRule>();
        }

        [Fact]
        public void Or_method_should_return_ITypesFilterPostCondition_instance_when_has_predicate()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All;

            // Act
            var conditions = filters.That.AreClasses().Or(a => a.AreInterfaces());

            // Assert
            conditions.Should().BeAssignableTo<ITypeDefinitionFilterSequence>();
        }
    }
}
