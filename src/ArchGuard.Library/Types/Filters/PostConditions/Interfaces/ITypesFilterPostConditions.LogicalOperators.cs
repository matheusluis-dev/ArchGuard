namespace ArchGuard.Library.Types.Filters.PostConditions.Interfaces;

public partial interface ITypesFilterPostConditions
{
    ITypesFilterConditions And();
    ITypesFilterPostConditions And(Func<ITypesFilterConditions, ITypesFilterPostConditions> filter);

    ITypesFilterConditions Or();
    ITypesFilterPostConditions Or(Func<ITypesFilterConditions, ITypesFilterPostConditions> filter);
}
