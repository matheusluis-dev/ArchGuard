namespace ArchGuard
{
    public partial interface ITypeFilterRule
    {
        ITypeFilterSequence HaveName(params string[] name);

        ITypeFilterSequence HaveNameMatching(params string[] regexes);
        ITypeFilterSequence HaveNameNotMatching(params string[] regexes);

        ITypeFilterSequence HaveFullName(params string[] name);

        ITypeFilterSequence HaveFullNameMatching(params string[] regexes);
        ITypeFilterSequence HaveFullNameNotMatching(params string[] regexes);

        ITypeFilterSequence HaveNameStartingWith(params string[] name);
        ITypeFilterSequence HaveNameEndingWith(params string[] name);
    }
}
