namespace ArchGuard
{
    public partial interface ITypeAssertionRule
    {
        ITypeAssertionSequence HaveName(params string[] name);

        ITypeAssertionSequence HaveNameMatching(params string[] regexes);
        ITypeAssertionSequence HaveNameNotMatching(params string[] regexes);

        ITypeAssertionSequence HaveFullName(params string[] name);

        ITypeAssertionSequence HaveFullNameMatching(params string[] regexes);
        ITypeAssertionSequence HaveFullNameNotMatching(params string[] regexes);

        ITypeAssertionSequence HaveNameStartingWith(params string[] name);
        ITypeAssertionSequence HaveNameEndingWith(params string[] name);
    }
}
