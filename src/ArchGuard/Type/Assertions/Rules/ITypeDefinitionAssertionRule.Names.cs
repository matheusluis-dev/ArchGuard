namespace ArchGuardType.Assertions
{
    using ArchGuardType.Assertions.Sequences;

    public partial interface ITypeDefinitionAssertionRule
    {
        ITypeDefinitionAssertionSequence HaveName(params string[] names);
        ITypeDefinitionAssertionSequence HaveFullName(params string[] names);
        ITypeDefinitionAssertionSequence HaveNameStartingWith(params string[] names);
        ITypeDefinitionAssertionSequence HaveNameEndingWith(params string[] names);
    }
}
