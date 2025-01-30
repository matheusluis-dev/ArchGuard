namespace ArchGuard
{
    public sealed partial class TypeDefinitionFilter
    {
        public ITypeDefinitionAssertionRule Should => _startAssertionCallback.Invoke();
    }
}
