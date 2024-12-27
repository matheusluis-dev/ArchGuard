namespace ArchGuard.Library.Types.Filters.Interfaces;

using ArchGuard.Library.Types.Filters.Interfaces;

public partial interface ITypesFilterCondition
{
    ITypesFilterPostCondition ArePublic();
    ITypesFilterPostCondition AreNotPublic();

    ITypesFilterPostCondition AreInternal();
    ITypesFilterPostCondition AreNotInternal();

    ITypesFilterPostCondition ArePrivate();
    ITypesFilterPostCondition AreNotPrivate();

    ITypesFilterPostCondition ArePartial();
    ITypesFilterPostCondition AreNotPartial();

    ITypesFilterPostCondition AreSealed();
    ITypesFilterPostCondition AreNotSealed();
}
