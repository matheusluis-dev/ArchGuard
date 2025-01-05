namespace ArchGuard.Filters.Tests.Types
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class NamesTests
    {
        [Fact]
        public void Name_starting()
        {
            // Arrange
            var prefix = "PublicSealed";
            var filters = TypesFromMockedAssembly.All.That.HaveNameStartingWith(prefix);

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    new List<string>
                    {
                        TypeNames.PublicSealedClass,
#if NET5_0_OR_GREATER
                        TypeNames.PublicSealedRecord,
#endif
                    }
                );
        }

        [Fact]
        public void Name_starting_with_StringComparison()
        {
            // Arrange
            var prefix = "PublicSealed";
            var filters = TypesFromMockedAssembly.All.That.HaveNameStartingWith(
                prefix.ToUpperInvariant(),
                StringComparison.OrdinalIgnoreCase
            );

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    new List<string>
                    {
                        TypeNames.PublicSealedClass,
#if NET5_0_OR_GREATER
                        TypeNames.PublicSealedRecord,
#endif
                    }
                );
        }

        [Fact]
        public void Name_ending()
        {
            // Arrange
            var suffix = "Class";

            var filters = TypesFromMockedAssembly.All.That.HaveNameEndingWith(suffix);

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    new List<string>
                    {
#if NET7_0_OR_GREATER
                        TypeNames.FileClass,
                        TypeNames.FilePartialClass,
                        TypeNames.FileSealedClass,
                        TypeNames.FileStaticClass,
#endif

                        TypeNames.InternalClass,
                        TypeNames.InternalPartialClass,
                        TypeNames.InternalSealedClass,
                        TypeNames.InternalStaticClass,
                        TypeNames.PublicAbstractClass,
                        TypeNames.PublicClass,
                        TypeNames.PublicParentClass,
                        TypeNames.PublicParentClass_InternalNestedClass,
                        TypeNames.PublicParentClass_PrivateNestedClass,
                        TypeNames.PublicParentClass_PublicNestedClass,
                        TypeNames.PublicParentClass_PublicNestedPartialClass,
                        TypeNames.PublicPartialClass,
                        TypeNames.PublicSealedClass,
                        TypeNames.PublicStaticClass,
                    }
                );
        }

        [Fact]
        public void Name_ending_with_StringComparison()
        {
            // Arrange
            var suffix = "Class";
            var filters = TypesFromMockedAssembly.All.That.HaveNameEndingWith(
                suffix.ToUpperInvariant(),
                StringComparison.OrdinalIgnoreCase
            );

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types
                .Should()
                .BeEquivalentTo(
                    new List<string>
                    {
#if NET7_0_OR_GREATER
                        TypeNames.FileClass,
                        TypeNames.FilePartialClass,
                        TypeNames.FileSealedClass,
                        TypeNames.FileStaticClass,
#endif
                        TypeNames.InternalClass,
                        TypeNames.InternalPartialClass,
                        TypeNames.InternalSealedClass,
                        TypeNames.InternalStaticClass,
                        TypeNames.PublicAbstractClass,
                        TypeNames.PublicClass,
                        TypeNames.PublicParentClass,
                        TypeNames.PublicParentClass_InternalNestedClass,
                        TypeNames.PublicParentClass_PrivateNestedClass,
                        TypeNames.PublicParentClass_PublicNestedClass,
                        TypeNames.PublicParentClass_PublicNestedPartialClass,
                        TypeNames.PublicPartialClass,
                        TypeNames.PublicSealedClass,
                        TypeNames.PublicStaticClass,
                    }
                );
        }
    }
}
