namespace ArchGuard.Library.Types.Filters.Conditions.Interfaces;

public partial interface ITypesFilterConditions
{
    ITypesFilterPostConditions AreClasses();
    ITypesFilterPostConditions AreNotClasses();

    ITypesFilterPostConditions AreInterfaces();
    ITypesFilterPostConditions AreNotInterfaces();

    ITypesFilterPostConditions AreStructs();
    ITypesFilterPostConditions AreNotStructs();

    ITypesFilterPostConditions AreEnums();
    ITypesFilterPostConditions AreNotEnums();

    ITypesFilterPostConditions AreRecords();
    ITypesFilterPostConditions AreNotRecords();
}
