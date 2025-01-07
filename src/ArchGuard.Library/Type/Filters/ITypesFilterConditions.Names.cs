namespace ArchGuard.Library.Type.Filters.Conditions.Interfaces
{
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public partial interface ITypesFilterConditions
    {
        ITypesFilterPostConditions HaveName(string name);
        ITypesFilterPostConditions HaveFullName(string name);
        ITypesFilterPostConditions HaveNameStartingWith(string name);
        ITypesFilterPostConditions HaveNameEndingWith(string name);
    }
}
