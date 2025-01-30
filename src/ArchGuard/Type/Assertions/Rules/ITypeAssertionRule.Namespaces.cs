namespace ArchGuard
{
    public partial interface ITypeAssertionRule
    {
        ITypeAssertionSequence ResideInNamespace(params string[] name);
        ITypeAssertionSequence NotResideInNamespace(params string[] name);

        ITypeAssertionSequence ResideInNamespaceContaining(params string[] name);
        ITypeAssertionSequence NotResideInNamespaceContaining(params string[] name);

        ITypeAssertionSequence ResideInNamespaceEndingWith(params string[] name);
        ITypeAssertionSequence NotResideInNamespaceEndingWith(params string[] name);
    }
}
