namespace ArchGuard
{
    public interface IGetMethodResult
    {
        MethodAssertionResult GetResult();
        MethodAssertionResult GetResult(StringComparison comparison);
    }
}
