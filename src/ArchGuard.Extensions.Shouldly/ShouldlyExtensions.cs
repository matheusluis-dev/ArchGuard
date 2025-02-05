namespace ArchGuard.Extensions.Shouldly
{
    using ArchGuard.Core.Method.Models;
    using ArchGuard.Core.Type.Models;

    public static class ShouldlyExtensions
    {
        public static void ShouldBeSuccess(this TypeAssertionResult typeAssertionResult)
        {
            typeAssertionResult.ShouldNotBeNull();
            typeAssertionResult.IsSuccessful.ShouldBeTrue();
        }

        public static void ShouldBeSuccess(this MethodAssertionResult methodAssertionResult)
        {
            methodAssertionResult.ShouldNotBeNull();
            methodAssertionResult.IsSuccessful.ShouldBeTrue();
        }
    }
}
