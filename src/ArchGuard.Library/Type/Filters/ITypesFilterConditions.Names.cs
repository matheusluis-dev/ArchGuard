namespace ArchGuard.Library.Type.Filters.Conditions.Interfaces
{
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public partial interface ITypesFilterConditions
    {
        ITypesFilterPostConditions HaveName(params string[] name);
        ITypesFilterPostConditions HaveFullName(params string[] name);
        ITypesFilterPostConditions HaveNameStartingWith(params string[] name);
        ITypesFilterPostConditions HaveNameEndingWith(params string[] name);
    }
}
