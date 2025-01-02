namespace ArchGuard.Tests
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Tests.Common.Types;
    using FluentAssertions;
    using Xunit;

    public sealed partial class ImplementsInterfaceTests
    {
        [Theory]
        [ClassData(typeof(ActionsIPublicInterface))]
        public void Implements_interface_with_explicit_type_argument(
            Func<IEnumerable<string>> filters
        )
        {
            // Act
            var types = filters.Invoke();

            // Assert
            types.Should().ContainSingle().And.Contain(TypeNames.PublicClass);
        }

        [Theory]
        [ClassData(typeof(ActionsPublicClass))]
        public void Implements_interface_should_throw_Exception_when_type_is_not_interface(
            Func<IEnumerable<string>> filters
        )
        {
            // Assert
            filters
                .Should()
                .ThrowExactly<ArgumentException>()
                .WithMessage("Type must be an interface*");
        }
    }
}
