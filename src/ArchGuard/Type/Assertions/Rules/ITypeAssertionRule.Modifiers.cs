namespace ArchGuard
{
    public partial interface ITypeAssertionRule
    {
        ITypeAssertionSequence BePartial();
        ITypeAssertionSequence NotBePartial();

        ITypeAssertionSequence BeSealed();
        ITypeAssertionSequence NotBeSealed();

        ITypeAssertionSequence BeNested();
        ITypeAssertionSequence NotBeNested();

        ITypeAssertionSequence BeStatic();
        ITypeAssertionSequence NotBeStatic();

        ITypeAssertionSequence BeAbstract();
        ITypeAssertionSequence NotBeAbstract();
    }
}
