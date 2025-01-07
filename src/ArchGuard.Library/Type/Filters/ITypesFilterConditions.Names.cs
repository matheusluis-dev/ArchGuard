namespace ArchGuard.Library.Type.Filters.Conditions.Interfaces
{
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public partial interface ITypesFilterConditions
    {
        ITypesFilterPostConditions HaveName(params string[] name);

        ITypesFilterPostConditions HaveNameMatching(params string[] regexes);
        ITypesFilterPostConditions HaveNameNotMatching(params string[] regexes);

        ITypesFilterPostConditions HaveFullName(params string[] name);

        ITypesFilterPostConditions HaveFullNameMatching(params string[] regexes);
        ITypesFilterPostConditions HaveFullNameNotMatching(params string[] regexes);

        ITypesFilterPostConditions HaveNameStartingWith(params string[] name);
        ITypesFilterPostConditions HaveNameEndingWith(params string[] name);
    }
}
