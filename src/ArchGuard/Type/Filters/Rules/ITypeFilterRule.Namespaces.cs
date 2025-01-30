namespace ArchGuard
{
    public partial interface ITypeFilterRule
    {
        ITypeFilterSequence ResideInNamespace(params string[] name);

        ITypeFilterSequence ResideInNamespaceContaining(params string[] name);

        ITypeFilterSequence ResideInNamespaceEndingWith(params string[] name);
        ITypeFilterSequence DoNotResideInNamespace(params string[] name);

        ITypeFilterSequence DoNotResideInNamespaceContaining(params string[] name);

        ITypeFilterSequence DoNotResideInNamespaceEndingWith(params string[] name);
    }
}
