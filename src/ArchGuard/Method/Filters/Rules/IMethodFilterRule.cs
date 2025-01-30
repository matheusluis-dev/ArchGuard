namespace ArchGuard
{
    public partial interface IMethodFilterRule
    {
        IMethodFilterSequence AreAsynchronous();
        IMethodFilterSequence AreNotAsynchronous();
    }
}
