namespace ArchGuard
{
    using ArchGuard.Core.Contexts;
    using ArchGuard.Core.Property.Models;

    public interface IPropertyGetResult
    {
        AssertionResult<PropertyDefinition> GetResult();
        AssertionResult<PropertyDefinition> GetResult(StringComparison comparison);
    }
}
