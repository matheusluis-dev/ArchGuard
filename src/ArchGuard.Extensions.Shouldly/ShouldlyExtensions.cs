namespace ArchGuard.Extensions.Shouldly
{
    using ArchGuard.Core.Contexts;
    using ArchGuard.Core.Field.Models;
    using ArchGuard.Core.Method.Models;
    using ArchGuard.Core.Property.Models;
    using ArchGuard.Core.Slice.Models;
    using ArchGuard.Core.Type.Models;

    public static class ShouldlyExtensions
    {
        public static void ShouldBeSuccess(this AssertionResult<TypeDefinition> typeAssertionResult)
        {
            typeAssertionResult.ShouldNotBeNull();
            typeAssertionResult.IsSuccessful.ShouldBeTrue();
        }

        public static void ShouldBeSuccess(this AssertionResult<MethodDefinition> methodAssertionResult)
        {
            methodAssertionResult.ShouldNotBeNull();
            methodAssertionResult.IsSuccessful.ShouldBeTrue();
        }

        public static void ShouldBeSuccess(this AssertionResult<FieldDefinition> fieldAssertionResult)
        {
            fieldAssertionResult.ShouldNotBeNull();
            fieldAssertionResult.IsSuccessful.ShouldBeTrue();
        }

        public static void ShouldBeSuccess(this AssertionResult<PropertyDefinition> propertyAssertionResult)
        {
            propertyAssertionResult.ShouldNotBeNull();
            propertyAssertionResult.IsSuccessful.ShouldBeTrue();
        }

        public static void ShouldBeSuccess(this SliceAssertionResult sliceAssertionResult)
        {
            sliceAssertionResult.ShouldNotBeNull();
            sliceAssertionResult.IsSuccessful.ShouldBeTrue();
        }
    }
}
