namespace ArchGuard
{
    public partial interface IFieldAssertionRule
    {
        IFieldAssertionSequence BeStatic();
        IFieldAssertionSequence NotBeStatic();

        IFieldAssertionSequence BeConst();
        IFieldAssertionSequence NotBeConst();

        IFieldAssertionSequence BeReadonly();
        IFieldAssertionSequence NotBeReadonly();
    }
}
