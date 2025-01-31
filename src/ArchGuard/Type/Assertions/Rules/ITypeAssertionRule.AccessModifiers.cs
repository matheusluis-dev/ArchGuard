namespace ArchGuard
{
    public partial interface ITypeAssertionRule
    {
        ITypeAssertionSequence BePublic();
        ITypeAssertionSequence NotBePublic();

        ITypeAssertionSequence BeInternal();
        ITypeAssertionSequence NotBeInternal();

        ITypeAssertionSequence BePrivate();
        ITypeAssertionSequence NotBePrivate();

        ITypeAssertionSequence BeProtected();
        ITypeAssertionSequence NotBeProtected();

        ITypeAssertionSequence BeFileLocal();
        ITypeAssertionSequence NotBeFileLocal();
    }
}
