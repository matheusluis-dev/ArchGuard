namespace ArchGuard
{
    public partial interface IFieldAssertionSequence : IFieldGetResult
    {
        IFieldAssertionRule And { get; }
        IFieldAssertionRule Or { get; }
    }
}
