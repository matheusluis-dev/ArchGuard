namespace ArchGuard.Library.Type.Filters
{
    public partial interface ITypeDefinitionFilterRule
    {
        ITypeDefinitionFilterSequence ResideInNamespace(params string[] name);

        ITypeDefinitionFilterSequence ResideInNamespaceContaining(params string[] name);

        ITypeDefinitionFilterSequence ResideInNamespaceEndingWith(params string[] name);
        ITypeDefinitionFilterSequence DoNotResideInNamespace(params string[] name);

        ITypeDefinitionFilterSequence DoNotResideInNamespaceContaining(params string[] name);

        ITypeDefinitionFilterSequence DoNotResideInNamespaceEndingWith(params string[] name);
    }
}
