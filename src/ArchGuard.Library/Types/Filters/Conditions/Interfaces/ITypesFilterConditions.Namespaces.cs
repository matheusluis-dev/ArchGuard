namespace ArchGuard.Library.Types.Filters.Conditions.Interfaces;

public partial interface ITypesFilterConditions
{
    ITypesFilterPostConditions ResideInNamespace(string name);
    ITypesFilterPostConditions ResideInNamespace(string name, StringComparison comparer);

    ITypesFilterPostConditions NotResideInNamespace(string name);
    ITypesFilterPostConditions NotResideInNamespace(string name, StringComparison comparer);
}
