namespace ArchGuard
{
    public partial interface IMethodAssertionSequence : IGetMethodResult
    {
        IMethodAssertionRule And { get; }
        IMethodAssertionRule Or { get; }
    }
}
