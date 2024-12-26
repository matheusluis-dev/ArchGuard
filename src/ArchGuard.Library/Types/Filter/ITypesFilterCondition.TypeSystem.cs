namespace ArchGuard.Library.Types.Filter;

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
}
