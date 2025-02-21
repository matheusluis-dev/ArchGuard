namespace ArchGuard
{
    using ArchGuard.Core.Contexts;
    using ArchGuard.Core.Field.Models;

    public interface IFieldGetResult
    {
        AssertionResult<FieldDefinition> GetResult();
        AssertionResult<FieldDefinition> GetResult(StringComparison comparison);
    }
}
