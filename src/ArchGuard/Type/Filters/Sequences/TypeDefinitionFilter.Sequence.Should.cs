namespace ArchGuardType.Filters
{
    using ArchGuardType.Assertions;

    public sealed partial class TypeDefinitionFilter
    {
        public ITypeDefinitionAssertionRule Should => _startAssertionCallback.Invoke();
    }
}
