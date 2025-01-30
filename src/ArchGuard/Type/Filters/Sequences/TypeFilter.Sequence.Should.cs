namespace ArchGuard
{
    public sealed partial class TypeFilter
    {
        public ITypeAssertionRule Should => _startAssertionCallback.Invoke();
    }
}
