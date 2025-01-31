namespace ArchGuard
{
    public partial interface IMethodAssertionRule
    {
        IMethodAssertionSequence BeAsynchronous();
        IMethodAssertionSequence NotBeAsynchronous();

        IMethodAssertionSequence BeStatic();
        IMethodAssertionSequence NotBeStatic();
    }
}
