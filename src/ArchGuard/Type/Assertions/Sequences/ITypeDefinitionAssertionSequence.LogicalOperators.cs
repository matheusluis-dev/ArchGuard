namespace ArchGuardType.Assertions.Sequences
{
#pragma warning disable CA1716 // Identifiers should not match keywords
    public partial interface ITypeDefinitionAssertionSequence
    {
        ITypeDefinitionAssertionRule And { get; }
        ITypeDefinitionAssertionRule Or { get; }
    }
#pragma warning restore CA1716 // Identifiers should not match keywords
}
