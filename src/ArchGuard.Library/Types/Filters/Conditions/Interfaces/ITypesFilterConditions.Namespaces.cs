namespace ArchGuard.Library.Types.Filters.Conditions.Interfaces
{
    using System;
    using ArchGuard.Library.Types.Filters.PostConditions.Interfaces;

    public partial interface ITypesFilterConditions
    {
        ITypesFilterPostConditions ResideInNamespace(string name);
        ITypesFilterPostConditions ResideInNamespace(string name, StringComparison comparer);

        ITypesFilterPostConditions NotResideInNamespace(string name);
        ITypesFilterPostConditions NotResideInNamespace(string name, StringComparison comparer);
    }
}
