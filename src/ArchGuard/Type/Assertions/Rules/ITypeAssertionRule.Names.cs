namespace ArchGuard
{
    public partial interface ITypeAssertionRule
    {
        ITypeAssertionSequence HaveName(params string[] name);

        ITypeAssertionSequence HaveNameMatching(params string[] regexes);
        ITypeAssertionSequence NotHaveNameMatching(params string[] regexes);

        ITypeAssertionSequence HaveFullName(params string[] name);

        ITypeAssertionSequence HaveFullNameMatching(params string[] regexes);
        ITypeAssertionSequence NotHaveFullNameMatching(params string[] regexes);

        ITypeAssertionSequence HaveNameStartingWith(params string[] name);
        ITypeAssertionSequence NotHaveNameStartingWith(params string[] names);

        ITypeAssertionSequence HaveNameEndingWith(params string[] name);
        ITypeAssertionSequence NotHaveNameEndingWith(params string[] names);
    }
}
