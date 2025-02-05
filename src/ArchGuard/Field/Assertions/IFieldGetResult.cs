namespace ArchGuard
{
    using ArchGuard.Core.Field.Models;

    public interface IFieldGetResult
    {
        FieldAssertionResult GetResult();
        FieldAssertionResult GetResult(StringComparison comparison);
    }
}
