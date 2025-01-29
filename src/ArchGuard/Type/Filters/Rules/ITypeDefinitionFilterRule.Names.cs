namespace ArchGuardType.Filters
{
    public partial interface ITypeDefinitionFilterRule
    {
        ITypeDefinitionFilterSequence HaveName(params string[] name);

        ITypeDefinitionFilterSequence HaveNameMatching(params string[] regexes);
        ITypeDefinitionFilterSequence HaveNameNotMatching(params string[] regexes);

        ITypeDefinitionFilterSequence HaveFullName(params string[] name);

        ITypeDefinitionFilterSequence HaveFullNameMatching(params string[] regexes);
        ITypeDefinitionFilterSequence HaveFullNameNotMatching(params string[] regexes);

        ITypeDefinitionFilterSequence HaveNameStartingWith(params string[] name);
        ITypeDefinitionFilterSequence HaveNameEndingWith(params string[] name);
    }
}
