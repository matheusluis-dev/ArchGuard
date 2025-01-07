namespace ArchGuard.Assertions.Tests.Modifiers
{
    using System;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class StaticTests
    {
        [Fact]
        public void Static_types()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.HaveNameEndingWith("StaticClass");

            var filtersTypes = filters.GetTypes(StringComparison.Ordinal);

            // Act
            var assertion = filters.Should.BeStatic().GetResult(StringComparison.Ordinal);

            // Assert
            assertion.IsSuccessful.Should().BeTrue();
            assertion.TypesFiltered.Should().BeEquivalentTo(filtersTypes);
            assertion.CompliantTypes.Should().BeEquivalentTo(filtersTypes);
            assertion.NonCompliantTypes.Should().BeEmpty();
        }

        [Fact]
        public void Static_types_non_successful()
        {
            // Arrange
            var filters = TypesFromMockedAssembly.All.That.ResideInNamespace(Namespaces.Classes);

            var filtersTypes = filters.GetTypes(StringComparison.Ordinal);

            // Act
            var assertion = filters.Should.BeStatic().GetResult(StringComparison.Ordinal);

            // Assert
            assertion.IsSuccessful.Should().BeFalse();
            assertion.TypesFiltered.Should().BeEquivalentTo(filtersTypes);
            assertion
                .CompliantTypes.GetFullNames()
                .Should()
                .BeEquivalentTo(
#if NET7_0_OR_GREATER
                    TypeNames.FileStaticClass,
#endif
                    TypeNames.InternalStaticClass,
                    TypeNames.PublicStaticClass
                );
            assertion
                .NonCompliantTypes.GetFullNames()
                .Should()
                .BeEquivalentTo(
#if NET7_0_OR_GREATER
                    TypeNames.FileClass,
                    TypeNames.FilePartialClass,
                    TypeNames.FileSealedClass,
#endif
                    TypeNames.InternalClass,
                    TypeNames.InternalPartialClass,
                    TypeNames.InternalSealedClass,
                    TypeNames.PublicAbstractClass,
                    TypeNames.PublicClass,
                    TypeNames.PublicGenericClassWithOneType,
                    TypeNames.PublicGenericClassWithTwoTypes,
                    TypeNames.PublicParentClass,
                    TypeNames.PublicParentClass_InternalNestedClass,
                    TypeNames.PublicParentClass_PrivateNestedClass,
                    TypeNames.PublicParentClass_PublicNestedClass,
                    TypeNames.PublicParentClass_PublicNestedPartialClass,
                    TypeNames.PublicPartialClass,
                    TypeNames.PublicSealedClass
                );
        }
    }
}
