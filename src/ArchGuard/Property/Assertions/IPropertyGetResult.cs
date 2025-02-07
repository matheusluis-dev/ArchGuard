namespace ArchGuard
{
    using ArchGuard.Core.Property.Models;

    public interface IPropertyGetResult
    {
        PropertyAssertionResult GetResult();
        PropertyAssertionResult GetResult(StringComparison comparison);
    }
}
