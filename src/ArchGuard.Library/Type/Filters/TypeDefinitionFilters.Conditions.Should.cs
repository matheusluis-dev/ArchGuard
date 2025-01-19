namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Assertions;

    public sealed partial class TypeDefinitionFilters
    {
        public ITypesAssertionCondition Should => _callback.Invoke();
    }
}
