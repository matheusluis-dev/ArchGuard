namespace ArchGuard.Roslyn.Type.Filters
{
    public partial interface ITypesFilterConditions
    {
        ITypesFilterPostConditions ArePublic();
        ITypesFilterPostConditions AreNotPublic();

        ITypesFilterPostConditions AreInternal();
        ITypesFilterPostConditions AreNotInternal();

        ITypesFilterPostConditions ArePrivate();
        ITypesFilterPostConditions AreNotPrivate();

        ITypesFilterPostConditions AreProtected();
        ITypesFilterPostConditions AreNotProtected();

        ITypesFilterPostConditions AreFileScoped();
        ITypesFilterPostConditions AreNotFileScoped();
    }
}
