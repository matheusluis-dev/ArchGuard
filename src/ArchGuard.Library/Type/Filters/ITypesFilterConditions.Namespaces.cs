namespace ArchGuard.Library.Type.Filters.Conditions.Interfaces
{
    using System;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public partial interface ITypesFilterConditions
    {
        ITypesFilterPostConditions ResideInNamespace(string name);
        ITypesFilterPostConditions ResideInNamespace(string name, StringComparison comparison);

        ITypesFilterPostConditions ResideInNamespaceContaining(string name);
        ITypesFilterPostConditions ResideInNamespaceContaining(
            string name,
            StringComparison comparison
        );

        ITypesFilterPostConditions ResideInNamespaceEndingWith(string name);
        ITypesFilterPostConditions ResideInNamespaceEndingWith(
            string name,
            StringComparison comparison
        );

        ITypesFilterPostConditions DoNotResideInNamespace(string name);
        ITypesFilterPostConditions DoNotResideInNamespace(string name, StringComparison comparison);

        ITypesFilterPostConditions DoNotResideInNamespaceContaining(string name);
        ITypesFilterPostConditions DoNotResideInNamespaceContaining(
            string name,
            StringComparison comparison
        );

        ITypesFilterPostConditions DoNotResideInNamespaceEndingWith(string name);
        ITypesFilterPostConditions DoNotResideInNamespaceEndingWith(
            string name,
            StringComparison comparison
        );
    }
}
