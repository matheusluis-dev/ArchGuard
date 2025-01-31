namespace ArchGuard
{
    public partial interface IMethodFilterRule
    {
        IMethodFilterSequence AreAsynchronous();
        IMethodFilterSequence AreNotAsynchronous();

        IMethodFilterSequence AreStatic();
        IMethodFilterSequence AreNotStatic();
    }
}
