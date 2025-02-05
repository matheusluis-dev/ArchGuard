namespace ArchGuard
{
    using ArchGuard.Core.Method.Models;

    public interface IGetMethodResult
    {
        MethodAssertionResult GetResult();
        MethodAssertionResult GetResult(StringComparison comparison);
    }
}
