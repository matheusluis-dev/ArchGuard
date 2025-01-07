namespace ArchGuard.Library.Type.Filters.Conditions.Interfaces
{
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public partial interface ITypesFilterConditions
    {
        ITypesFilterPostConditions HaveName(params string[] name);

        ITypesFilterPostConditions HaveNameMatching(string regex);
        ITypesFilterPostConditions HaveNameNotMatching(string regex);

        ITypesFilterPostConditions HaveFullName(params string[] name);

        ITypesFilterPostConditions HaveFullNameMatching(string regex);
        ITypesFilterPostConditions HaveFullNameNotMatching(string regex);

        ITypesFilterPostConditions HaveNameStartingWith(params string[] name);
        ITypesFilterPostConditions HaveNameEndingWith(params string[] name);
    }
}
