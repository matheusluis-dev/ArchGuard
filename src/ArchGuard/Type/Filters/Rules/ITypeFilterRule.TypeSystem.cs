namespace ArchGuard
{
    public partial interface ITypeFilterRule
    {
        ITypeFilterSequence AreClasses();
        ITypeFilterSequence AreNotClasses();

        ITypeFilterSequence AreInterfaces();
        ITypeFilterSequence AreNotInterfaces();

        ITypeFilterSequence AreStructs();
        ITypeFilterSequence AreNotStructs();

        ITypeFilterSequence AreEnums();
        ITypeFilterSequence AreNotEnums();

        ITypeFilterSequence AreRecords();
        ITypeFilterSequence AreNotRecords();

        ITypeFilterSequence AreRecordStructs();
        ITypeFilterSequence AreNotRecordStructs();
    }
}
