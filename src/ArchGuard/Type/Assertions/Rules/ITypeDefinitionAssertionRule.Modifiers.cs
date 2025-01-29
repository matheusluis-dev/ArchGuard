namespace ArchGuardType.Assertions
{
    using ArchGuardType.Assertions.Sequences;

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
