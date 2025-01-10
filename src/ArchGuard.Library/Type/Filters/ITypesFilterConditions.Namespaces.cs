namespace ArchGuard.Library.Type.Filters
{
    public partial interface ITypesFilterConditions
    {
        ITypesFilterPostConditions ResideInNamespace(params string[] name);

        ITypesFilterPostConditions ResideInNamespaceContaining(params string[] name);

        ITypesFilterPostConditions ResideInNamespaceEndingWith(params string[] name);
        ITypesFilterPostConditions DoNotResideInNamespace(params string[] name);

        ITypesFilterPostConditions DoNotResideInNamespaceContaining(params string[] name);

        ITypesFilterPostConditions DoNotResideInNamespaceEndingWith(params string[] name);
    }
}
