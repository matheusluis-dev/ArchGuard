namespace ArchGuard.Library.Type.Filters.Conditions.Interfaces
{
    using System;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public partial interface ITypesFilterConditions
    {
        ITypesFilterPostConditions ResideInNamespace(string name);
        ITypesFilterPostConditions ResideInNamespace(string name, StringComparison comparer);

        ITypesFilterPostConditions NotResideInNamespace(string name);
        ITypesFilterPostConditions NotResideInNamespace(string name, StringComparison comparer);
    }
}
