namespace ArchGuardType.Filters
{
    public partial interface ITypeDefinitionFilterRule
    {
        ITypeDefinitionFilterSequence ArePartial();
        ITypeDefinitionFilterSequence AreNotPartial();

        ITypeDefinitionFilterSequence AreSealed();
        ITypeDefinitionFilterSequence AreNotSealed();

        ITypeDefinitionFilterSequence AreNested();
        ITypeDefinitionFilterSequence AreNotNested();

        ITypeDefinitionFilterSequence AreStatic();
        ITypeDefinitionFilterSequence AreNotStatic();

        ITypeDefinitionFilterSequence AreAbstract();
        ITypeDefinitionFilterSequence AreNotAbstract();
    }
}
