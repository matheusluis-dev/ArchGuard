namespace ArchGuard.Library.Types.Filter;

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
}
