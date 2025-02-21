namespace ArchGuard
{
    using ArchGuard.Core.Contexts;
    using ArchGuard.Core.Method.Models;

    public interface IGetMethodResult
    {
        AssertionResult<MethodDefinition> GetResult();
        AssertionResult<MethodDefinition> GetResult(StringComparison comparison);
    }
}
