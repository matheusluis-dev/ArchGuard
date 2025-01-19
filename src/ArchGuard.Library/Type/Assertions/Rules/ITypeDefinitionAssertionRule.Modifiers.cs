namespace ArchGuard.Library.Type.Assertions
{
    using ArchGuard.Library.Type.Assertions.Sequences;

    public partial interface ITypeDefinitionAssertionRule
    {
        ITypeDefinitionAssertionSequence BePartial();
        ITypeDefinitionAssertionSequence NotBePartial();

        ITypeDefinitionAssertionSequence BeSealed();
        ITypeDefinitionAssertionSequence NotBeSealed();

        ITypeDefinitionAssertionSequence BeNested();
        ITypeDefinitionAssertionSequence NotBeNested();

        ITypeDefinitionAssertionSequence BeStatic();
        ITypeDefinitionAssertionSequence NotBeStatic();
    }
}
