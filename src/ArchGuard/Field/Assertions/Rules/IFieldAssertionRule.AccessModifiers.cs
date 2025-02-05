namespace ArchGuard
{
    public partial interface IFieldAssertionRule
    {
        IFieldAssertionSequence BePublic();
        IFieldAssertionSequence NotBePublic();

        IFieldAssertionSequence BeInternal();
        IFieldAssertionSequence NotBeInternal();

        IFieldAssertionSequence BeProtected();
        IFieldAssertionSequence NotBeProtected();

        IFieldAssertionSequence BePrivate();
        IFieldAssertionSequence NotBePrivate();
    }
}
