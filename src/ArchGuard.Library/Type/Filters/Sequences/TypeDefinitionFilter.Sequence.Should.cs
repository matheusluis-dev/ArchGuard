namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Assertions;

    public sealed partial class TypeDefinitionFilter
    {
        public ITypesAssertionCondition Should => _startAssertionCallback.Invoke();
    }
}
