namespace ArchGuard
{
    public interface ISliceFilterRule
    {
        ISliceFilterSequence ByNamespacePrefix(string namespacePrefix);
    }
}
