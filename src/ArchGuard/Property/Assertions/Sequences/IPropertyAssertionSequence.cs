namespace ArchGuard
{
    public partial interface IPropertyAssertionSequence : IPropertyGetResult
    {
        IPropertyAssertionRule And { get; }
        IPropertyAssertionRule Or { get; }
    }
}
