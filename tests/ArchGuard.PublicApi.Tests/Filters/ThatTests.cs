namespace ArchGuard.PublicApi.Tests.Filters
{
    using System;
    using System.Linq;
    using System.Reflection;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.MockedAssembly.Classes.Public;
    using ArchGuard.Type;
    using ArchGuard.Type.Filters.EntryPoint;
    using FluentAssertions;
    using Xunit;

    // TODO: fix this
    public sealed class ThatTests
    {
        [Fact]
        public void That_method_should_be_available_after_Types_is_instantiated()
        {
            // Arrange
            var types = typeof(Types);
            var typesMethodsName = new[] { "FromAssembly" };

            var iTypesFilterStart = typeof(ITypeDefinitionFilterEntryPoint);
            var iTypesFilterStartMembersName = new[] { "That" };

            // Act
            var typesMethods = types
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => typesMethodsName.Contains(m.Name, StringComparer.Ordinal));

            var iTypesFilterStartProperties = iTypesFilterStart
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => iTypesFilterStartMembersName.Contains(p.Name, StringComparer.Ordinal));

            var iTypesFilterStartMethods = iTypesFilterStart.GetExtensionMethods(
                typeof(PublicClass).Assembly
            );

            // Assert
            typesMethods
                .Should()
                .ContainSingle()
                .Which.ReturnType.Should()
                .BeAssignableTo<ITypeDefinitionFilterEntryPoint>();

            iTypesFilterStartMethods.Should().HaveCount(2);
        }
    }
}
