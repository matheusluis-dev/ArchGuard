namespace ArchGuard
{
    public partial interface IMethodAssertionSequence
    {

        IMethodAssertionRule And { get; }
        IMethodAssertionRule Or { get; }
    }
}
