namespace ArchGuard.Library.Type.Filters.Conditions.Interfaces
{
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public partial interface ITypesFilterConditions
    {
        ITypesFilterPostConditions ArePartial();
        ITypesFilterPostConditions AreNotPartial();

        ITypesFilterPostConditions AreSealed();
        ITypesFilterPostConditions AreNotSealed();

        ITypesFilterPostConditions AreNested();
        ITypesFilterPostConditions AreNotNested();

        ITypesFilterPostConditions AreStatic();
        ITypesFilterPostConditions AreNotStatic();
    }
}
