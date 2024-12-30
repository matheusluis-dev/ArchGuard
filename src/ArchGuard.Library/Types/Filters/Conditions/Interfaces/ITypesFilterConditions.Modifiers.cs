namespace ArchGuard.Library.Types.Filters.Conditions.Interfaces
{
    using ArchGuard.Library.Types.Filters.PostConditions.Interfaces;

    public partial interface ITypesFilterConditions
    {
        ITypesFilterPostConditions ArePartial();
        ITypesFilterPostConditions AreNotPartial();

        ITypesFilterPostConditions AreSealed();
        ITypesFilterPostConditions AreNotSealed();
    }
}
