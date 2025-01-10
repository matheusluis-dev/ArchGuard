namespace ArchGuard.Roslyn.Type.Filters
{
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
