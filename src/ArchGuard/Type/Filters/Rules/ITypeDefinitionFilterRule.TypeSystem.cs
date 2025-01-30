namespace ArchGuard
{
    public partial interface ITypeDefinitionFilterRule
    {
        ITypeDefinitionFilterSequence AreClasses();
        ITypeDefinitionFilterSequence AreNotClasses();

        ITypeDefinitionFilterSequence AreInterfaces();
        ITypeDefinitionFilterSequence AreNotInterfaces();

        ITypeDefinitionFilterSequence AreStructs();
        ITypeDefinitionFilterSequence AreNotStructs();

        ITypeDefinitionFilterSequence AreEnums();
        ITypeDefinitionFilterSequence AreNotEnums();

        ITypeDefinitionFilterSequence AreRecords();
        ITypeDefinitionFilterSequence AreNotRecords();

        ITypeDefinitionFilterSequence AreRecordStructs();
        ITypeDefinitionFilterSequence AreNotRecordStructs();
    }
}
