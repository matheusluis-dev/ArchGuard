namespace ArchGuard
{
    public partial interface ITypeFilterRule
    {
        ITypeFilterSequence HaveName(params string[] names);

        ITypeFilterSequence HaveNameMatching(params string[] regexes);
        ITypeFilterSequence NotHaveNameMatching(params string[] regexes);

        ITypeFilterSequence HaveFullName(params string[] names);

        ITypeFilterSequence HaveFullNameMatching(params string[] regexes);
        ITypeFilterSequence NotHaveFullNameMatching(params string[] regexes);

        ITypeFilterSequence HaveNameStartingWith(params string[] names);
        ITypeFilterSequence NotHaveNameStartingWith(params string[] names);

        ITypeFilterSequence HaveNameEndingWith(params string[] names);
        ITypeFilterSequence NotHaveNameEndingWith(params string[] names);
    }
}
