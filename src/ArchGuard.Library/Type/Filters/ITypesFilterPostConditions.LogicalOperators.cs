namespace ArchGuard.Library.Type.Filters.PostConditions.Interfaces
{
    using ArchGuard.Library.Type.Filters.Conditions.Interfaces;

#pragma warning disable CA1716 // Identifiers should not match keywords
    public partial interface ITypesFilterPostConditions
    {
        ITypesFilterConditions And { get; }
        ITypesFilterConditions Or { get; }
    }
#pragma warning restore CA1716 // Identifiers should not match keywords
}
