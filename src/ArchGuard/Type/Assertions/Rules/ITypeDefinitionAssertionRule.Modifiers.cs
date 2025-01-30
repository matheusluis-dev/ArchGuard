namespace ArchGuard
{
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

        ITypeDefinitionAssertionSequence BeAbstract();
        ITypeDefinitionAssertionSequence NotBeAbstract();
    }
}
