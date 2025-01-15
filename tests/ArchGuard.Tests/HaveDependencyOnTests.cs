namespace ArchGuard.Filters.Tests
{
    using System;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class HaveDependencyOnTests
    {
        [Fact]
        public void HaveDependencyOn_PublicClass()
        {
            // Arrange
            var filters = TypesFromMockedAssembly
                .All.That.ResideInNamespace(ArchGuard.Tests.Common.Namespaces.HaveDependencyOn)
                .And.HaveDependencyOn(TypeNames.HaveDependencyOn.PublicClass);

            // Act
            var types = filters.GetTypes(StringComparison.Ordinal).GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    TypeNames.HaveDependencyOn.PublicDependsOnPropertyClass,
                    TypeNames.HaveDependencyOn.PublicDependsOnFieldClass,
                    TypeNames.HaveDependencyOn.PublicDependsOnMethodParameterClass,
                    TypeNames.HaveDependencyOn.PublicDependsOnMethodReturnClass,
                    TypeNames.HaveDependencyOn.PublicDependsOnMethodBodyClass,
                    TypeNames.HaveDependencyOn.PublicDependsOnMethodBodyStaticCallClass,
                    TypeNames
                        .HaveDependencyOn
                        .PublicDependsOnMethodBodyCallingStaticConstructorClass,
                    TypeNames.HaveDependencyOn.PublicClassExternalStaticConstructor,
                    TypeNames.HaveDependencyOn.PublicDependsOnDirectlyClass,
                    TypeNames.HaveDependencyOn.PublicDependsOnIndirectlyClass
                );
        }
    }
}
