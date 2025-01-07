namespace ArchGuard.Assertions.Tests.Namespaces
{
    using System;
    using ArchGuard.Tests.Common;
    using FluentAssertions;
    using Xunit;

    public sealed class NamespaceTests
    {
        [Fact]
        public void Reside_in_namespace()
        {
            // Assert
            var filters = TypesFromMockedAssembly
                .All.That.AreNotNested()
                .And.HaveNameMatching(".*Internal.*");
            var filtersTypes = filters.GetTypes();

            // Act
            var assertion = filters
                .Should.ResideInNamespace(
                    Namespaces.ClassesInternal,
                    Namespaces.EnumsInternal,
                    Namespaces.InterfacesInternal,
                    Namespaces.RecordsInternal,
                    Namespaces.StructsInternal
                )
                .GetResult();

            // Assert
            assertion.IsSuccessful.Should().BeTrue();
            assertion.TypesFiltered.Should().BeEquivalentTo(filtersTypes);
            assertion.CompliantTypes.Should().BeEquivalentTo(filtersTypes);
            assertion.NonCompliantTypes.Should().BeEmpty();
        }

        [Fact]
        public void Reside_in_namespace_with_StringComparison()
        {
            // Assert
            var filters = TypesFromMockedAssembly
                .All.That.AreNotNested()
                .And.HaveNameMatching(".*Internal.*");
            var filtersTypes = filters.GetTypes(StringComparison.OrdinalIgnoreCase);

            // Act
            var assertion = filters
                .Should.ResideInNamespace(
                    Namespaces.ClassesInternal.ToUpperInvariant(),
                    Namespaces.EnumsInternal.ToUpperInvariant(),
                    Namespaces.InterfacesInternal.ToUpperInvariant(),
                    Namespaces.RecordsInternal.ToUpperInvariant(),
                    Namespaces.StructsInternal.ToUpperInvariant()
                )
                .GetResult(StringComparison.OrdinalIgnoreCase);

            // Assert
            assertion.IsSuccessful.Should().BeTrue();
            assertion.TypesFiltered.Should().BeEquivalentTo(filtersTypes);
            assertion.CompliantTypes.Should().BeEquivalentTo(filtersTypes);
            assertion.NonCompliantTypes.Should().BeEmpty();
        }

        [Fact]
        public void Not_reside_in_namespace()
        {
            // Assert
            var filters = TypesFromMockedAssembly
                .All.That.AreNotNested()
                .And.HaveNameMatching(".*Internal.*");
            var filtersTypes = filters.GetTypes();

            // Act
            var assertion = filters
                .Should.NotResideInNamespace(
                    Namespaces.ClassesPublic,
                    Namespaces.EnumsPublic,
                    Namespaces.InterfacesPublic,
                    Namespaces.RecordsPublic,
                    Namespaces.StructsPublic
                )
                .GetResult();

            // Assert
            assertion.IsSuccessful.Should().BeTrue();
            assertion.TypesFiltered.Should().BeEquivalentTo(filtersTypes);
            assertion.CompliantTypes.Should().BeEquivalentTo(filtersTypes);
            assertion.NonCompliantTypes.Should().BeEmpty();
        }

        [Fact]
        public void Not_reside_in_namespace_with_StringComparison()
        {
            // Assert
            var filters = TypesFromMockedAssembly
                .All.That.AreNotNested()
                .And.HaveNameMatching(".*Internal.*");
            var filtersTypes = filters.GetTypes(StringComparison.OrdinalIgnoreCase);

            // Act
            var assertion = filters
                .Should.NotResideInNamespace(
                    Namespaces.ClassesPublic.ToUpperInvariant(),
                    Namespaces.EnumsPublic.ToUpperInvariant(),
                    Namespaces.InterfacesPublic.ToUpperInvariant(),
                    Namespaces.RecordsPublic.ToUpperInvariant(),
                    Namespaces.StructsPublic.ToUpperInvariant()
                )
                .GetResult(StringComparison.OrdinalIgnoreCase);

            // Assert
            assertion.IsSuccessful.Should().BeTrue();
            assertion.TypesFiltered.Should().BeEquivalentTo(filtersTypes);
            assertion.CompliantTypes.Should().BeEquivalentTo(filtersTypes);
            assertion.NonCompliantTypes.Should().BeEmpty();
        }

        [Fact]
        public void Reside_in_namespace_ending_with()
        {
            // Assert
            var filters = TypesFromMockedAssembly
                .All.That.AreNotNested()
                .And.HaveNameMatching(".*Internal.*");
            var filtersTypes = filters.GetTypes(StringComparison.Ordinal);

            // Act
            var assertion = filters
                .Should.ResideInNamespaceEndingWith(".Internal")
                .GetResult(StringComparison.Ordinal);

            // Assert
            assertion.IsSuccessful.Should().BeTrue();
            assertion.TypesFiltered.Should().BeEquivalentTo(filtersTypes);
            assertion.CompliantTypes.Should().BeEquivalentTo(filtersTypes);
            assertion.NonCompliantTypes.Should().BeEmpty();
        }

        [Fact]
        public void Not_reside_in_namespace_ending_with()
        {
            // Assert
            var filters = TypesFromMockedAssembly
                .All.That.AreNotNested()
                .And.HaveNameMatching(".*Internal.*");
            var filtersTypes = filters.GetTypes(StringComparison.Ordinal);

            // Act
            var assertion = filters
                .Should.NotResideInNamespaceEndingWith(".Public")
                .GetResult(StringComparison.Ordinal);

            // Assert
            assertion.IsSuccessful.Should().BeTrue();
            assertion.TypesFiltered.Should().BeEquivalentTo(filtersTypes);
            assertion.CompliantTypes.Should().BeEquivalentTo(filtersTypes);
            assertion.NonCompliantTypes.Should().BeEmpty();
        }
    }
}
