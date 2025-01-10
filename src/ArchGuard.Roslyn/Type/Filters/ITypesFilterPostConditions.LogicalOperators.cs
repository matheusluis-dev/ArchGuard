namespace ArchGuard.Roslyn.Type.Filters
{
#pragma warning disable CA1716 // Identifiers should not match keywords
    public partial interface ITypesFilterPostConditions
    {
        ITypesFilterConditions And { get; }
        ITypesFilterConditions Or { get; }
    }
#pragma warning restore CA1716 // Identifiers should not match keywords
}
