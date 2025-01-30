namespace ArchGuard
{
    public partial interface ITypeAssertionRule
    {
        ITypeAssertionSequence BeClasses();
        ITypeAssertionSequence NotBeClasses();

        ITypeAssertionSequence BeInterfaces();
        ITypeAssertionSequence NotBeInterfaces();

        ITypeAssertionSequence BeStructs();
        ITypeAssertionSequence NotBeStructs();

        ITypeAssertionSequence BeEnums();
        ITypeAssertionSequence NotBeEnums();

        ITypeAssertionSequence BeRecords();
        ITypeAssertionSequence NotBeRecords();

        ITypeAssertionSequence BeRecordStructs();
        ITypeAssertionSequence NotBeRecordStructs();
    }
}
