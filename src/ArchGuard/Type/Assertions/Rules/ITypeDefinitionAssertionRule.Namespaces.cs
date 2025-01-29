namespace ArchGuardType.Assertions
{
    using ArchGuardType.Assertions.Sequences;

    public partial interface ITypeDefinitionAssertionRule
    {
        ITypeDefinitionAssertionSequence ResideInNamespace(params string[] name);
        ITypeDefinitionAssertionSequence NotResideInNamespace(params string[] name);

        ITypeDefinitionAssertionSequence ResideInNamespaceContaining(params string[] name);
        ITypeDefinitionAssertionSequence NotResideInNamespaceContaining(params string[] name);

        ITypeDefinitionAssertionSequence ResideInNamespaceEndingWith(params string[] name);
        ITypeDefinitionAssertionSequence NotResideInNamespaceEndingWith(params string[] name);
    }
}
