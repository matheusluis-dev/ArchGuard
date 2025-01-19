namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Assertions;

    public sealed partial class TypeDefinitionFilter
    {
        public ITypeDefinitionAssertionRule Should => _startAssertionCallback.Invoke();
    }
}
