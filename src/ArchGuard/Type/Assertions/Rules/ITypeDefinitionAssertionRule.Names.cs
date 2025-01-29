namespace ArchGuardType.Assertions
{
    using ArchGuardType.Assertions.Sequences;

    public partial interface ITypeDefinitionAssertionRule
    {
        ITypeDefinitionAssertionSequence HaveName(params string[] name);

        ITypeDefinitionAssertionSequence HaveNameMatching(params string[] regexes);
        ITypeDefinitionAssertionSequence HaveNameNotMatching(params string[] regexes);

        ITypeDefinitionAssertionSequence HaveFullName(params string[] name);

        ITypeDefinitionAssertionSequence HaveFullNameMatching(params string[] regexes);
        ITypeDefinitionAssertionSequence HaveFullNameNotMatching(params string[] regexes);

        ITypeDefinitionAssertionSequence HaveNameStartingWith(params string[] name);
        ITypeDefinitionAssertionSequence HaveNameEndingWith(params string[] name);
    }
}
