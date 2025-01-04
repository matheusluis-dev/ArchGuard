namespace ArchGuard.PublicApi.Tests.Filters
{
    using System;
    using System.Linq;
    using System.Reflection;
    using ArchGuard.Library.Type;
    using ArchGuard.Library.Type.Filters;
    using FluentAssertions;
    using Xunit;

    public sealed class ThatTests
    {
        [Fact]
        public void That_method_should_be_available_after_Types_is_instantiated()
        {
            // Arrange
            var types = typeof(Types);
            var typesMethodsName = new[] { "FromAssembly" };

            var iTypesFilterStart = typeof(ITypesFilterStart);
            var iTypesFilterStartMethodsName = new[] { "That" };

            // Act
            var typesMethods = types
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => typesMethodsName.Contains(m.Name, StringComparer.Ordinal));

            var iTypesFilterStartMethods = iTypesFilterStart
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => iTypesFilterStartMethodsName.Contains(m.Name, StringComparer.Ordinal));

            // Assert
            typesMethods
                .Should()
                .ContainSingle()
                .Which.ReturnType.Should()
                .BeAssignableTo<ITypesFilterStart>();

            iTypesFilterStartMethods.Should().HaveCount(2);
        }
    }
}
