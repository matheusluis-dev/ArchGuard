namespace ArchGuardType.Filters
{
#pragma warning disable CA1716 // Identifiers should not match keywords
    public partial interface ITypeDefinitionFilterSequence
    {
        ITypeDefinitionFilterRule And { get; }
        ITypeDefinitionFilterRule Or { get; }
    }
#pragma warning restore CA1716 // Identifiers should not match keywords
}
