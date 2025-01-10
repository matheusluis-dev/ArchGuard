namespace ArchGuard.Roslyn.Type.Filters
{
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
