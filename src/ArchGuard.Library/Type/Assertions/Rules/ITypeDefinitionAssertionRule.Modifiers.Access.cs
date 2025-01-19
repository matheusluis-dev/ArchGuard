namespace ArchGuard.Library.Type.Assertions
{
    using ArchGuard.Library.Type.Assertions.Sequences;

    public partial interface ITypeDefinitionAssertionRule
    {
        ITypeDefinitionAssertionSequence BePublic();
        ITypeDefinitionAssertionSequence NotBePublic();

        ITypeDefinitionAssertionSequence BeInternal();
        ITypeDefinitionAssertionSequence NotBeInternal();

        ITypeDefinitionAssertionSequence BePrivate();
        ITypeDefinitionAssertionSequence NotBePrivate();

        ITypeDefinitionAssertionSequence BeProtected();
        ITypeDefinitionAssertionSequence NotBeProtected();

        ITypeDefinitionAssertionSequence BeFileScoped();
        ITypeDefinitionAssertionSequence NotBeFileScoped();
    }
}
