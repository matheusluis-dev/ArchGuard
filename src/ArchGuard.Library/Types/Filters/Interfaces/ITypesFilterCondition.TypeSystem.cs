namespace ArchGuard.Library.Types.Filters.Interfaces;

public partial interface ITypesFilterCondition
{
    ITypesFilterPostCondition AreClasses();
    ITypesFilterPostCondition AreNotClasses();

    ITypesFilterPostCondition AreInterfaces();
    ITypesFilterPostCondition AreNotInterfaces();

    ITypesFilterPostCondition AreStructs();
    ITypesFilterPostCondition AreNotStructs();

    ITypesFilterPostCondition AreEnums();
    ITypesFilterPostCondition AreNotEnums();

    ITypesFilterPostCondition AreRecords();
    ITypesFilterPostCondition AreNotRecords();
}
