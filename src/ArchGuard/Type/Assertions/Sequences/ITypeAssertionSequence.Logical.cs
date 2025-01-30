namespace ArchGuard
{
#pragma warning disable CA1716 // Identifiers should not match keywords
    public partial interface ITypeAssertionSequence
    {
        ITypeAssertionRule And { get; }
        ITypeAssertionRule Or { get; }
    }
#pragma warning restore CA1716 // Identifiers should not match keywords
}
