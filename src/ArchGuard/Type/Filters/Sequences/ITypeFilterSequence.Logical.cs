namespace ArchGuard
{
#pragma warning disable CA1716 // Identifiers should not match keywords
    public partial interface ITypeFilterSequence
    {
        ITypeFilterRule And { get; }
        ITypeFilterRule Or { get; }
    }
#pragma warning restore CA1716 // Identifiers should not match keywords
}
