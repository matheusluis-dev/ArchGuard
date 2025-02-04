namespace ArchGuard.Extensions.Shouldly
{
    public static class ShouldlyExtensions
    {
        public static void ShouldBeSuccess(this TypeAssertionResult typeAssertionResult)
        {
            typeAssertionResult.ShouldNotBeNull();
            typeAssertionResult.IsSuccessful.ShouldBeTrue();
        }
    }
}
