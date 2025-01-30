namespace ArchGuard
{
    public partial interface ITypeDefinitionAssertionRule
    {
        ITypeDefinitionAssertionSequence BeClasses();
        ITypeDefinitionAssertionSequence NotBeClasses();

        ITypeDefinitionAssertionSequence BeInterfaces();
        ITypeDefinitionAssertionSequence NotBeInterfaces();

        ITypeDefinitionAssertionSequence BeStructs();
        ITypeDefinitionAssertionSequence NotBeStructs();

        ITypeDefinitionAssertionSequence BeEnums();
        ITypeDefinitionAssertionSequence NotBeEnums();

        ITypeDefinitionAssertionSequence BeRecords();
        ITypeDefinitionAssertionSequence NotBeRecords();

        ITypeDefinitionAssertionSequence BeRecordStructs();
        ITypeDefinitionAssertionSequence NotBeRecordStructs();
    }
}
