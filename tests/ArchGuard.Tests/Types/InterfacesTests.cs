namespace ArchGuard.Tests.Types
{
    using System.Collections.Generic;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed class InterfacesTests
    {
        [Fact]
        public void Get_interfaces()
        {
            // Arrange
            var expected = new List<string>
            {
                TypeNames.IInternalInterface,
                TypeNames.IPublicInterface,
            };
            var filters = TypesFromMockedAssembly.All.That().AreInterfaces();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_non_interface_types()
        {
            // Arrange
            var expected = new List<string>
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
                TypeNames.PublicClass,
                TypeNames.PublicParentClass,
                TypeNames.PublicParentClass_InternalNestedClass,
                TypeNames.PublicParentClass_PrivateNestedClass,
                TypeNames.PublicParentClass_PublicNestedClass,
                TypeNames.PublicParentClass_PublicNestedPartialClass,
                TypeNames.PublicPartialClass,
                TypeNames.PublicSealedClass,
                TypeNames.PublicStaticClass,
                TypeNames.InternalEnum,
                TypeNames.PublicEnum,
#if NET5_0_OR_GREATER
                TypeNames.InternalRecord,
                TypeNames.InternalPartialRecord,
                TypeNames.InternalSealedRecord,
                TypeNames.PublicRecord,
                TypeNames.PublicPartialRecord,
                TypeNames.PublicSealedRecord,
#endif
                TypeNames.InternalStruct,
                TypeNames.PublicStruct,
            };
            var filters = TypesFromMockedAssembly.All.That().AreNotInterfaces();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_public_interfaces()
        {
            // Arrange
            var expected = new List<string> { TypeNames.IPublicInterface };
            var filters = TypesFromMockedAssembly.All.That().AreInterfaces().And().ArePublic();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_internal_interfaces()
        {
            // Arrange
            var expected = new List<string> { TypeNames.IInternalInterface };
            var filters = TypesFromMockedAssembly.All.That().AreInterfaces().And().AreInternal();

            // Act
            var types = filters.GetTypes().GetFullNames();

            // Assert
            types.Should().BeEquivalentTo(expected);
        }
    }
}
