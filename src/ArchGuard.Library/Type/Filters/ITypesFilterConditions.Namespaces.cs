namespace ArchGuard.Library.Type.Filters.Conditions.Interfaces
{
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public partial interface ITypesFilterConditions
    {
        ITypesFilterPostConditions ResideInNamespace(string name);

        ITypesFilterPostConditions ResideInNamespaceContaining(string name);

        ITypesFilterPostConditions ResideInNamespaceEndingWith(string name);
        ITypesFilterPostConditions DoNotResideInNamespace(string name);

        ITypesFilterPostConditions DoNotResideInNamespaceContaining(string name);

        ITypesFilterPostConditions DoNotResideInNamespaceEndingWith(string name);
    }
}
