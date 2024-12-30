namespace ArchGuard.Library.Types.Filters.Conditions.Interfaces
{
    using ArchGuard.Library.Types.Filters.PostConditions.Interfaces;

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
