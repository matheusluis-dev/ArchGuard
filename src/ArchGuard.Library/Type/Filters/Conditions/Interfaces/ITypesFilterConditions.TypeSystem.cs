namespace ArchGuard.Library.Type.Filters.Conditions.Interfaces
{
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

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

#if NET5_0_OR_GREATER
        ITypesFilterPostConditions AreRecords();
        ITypesFilterPostConditions AreNotRecords();
#endif
    }
}
