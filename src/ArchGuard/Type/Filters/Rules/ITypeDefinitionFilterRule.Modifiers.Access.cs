namespace ArchGuardType.Filters
{
    public partial interface ITypeDefinitionFilterRule
    {
        ITypeDefinitionFilterSequence ArePublic();
        ITypeDefinitionFilterSequence AreNotPublic();

        ITypeDefinitionFilterSequence AreInternal();
        ITypeDefinitionFilterSequence AreNotInternal();

        ITypeDefinitionFilterSequence ArePrivate();
        ITypeDefinitionFilterSequence AreNotPrivate();

        ITypeDefinitionFilterSequence AreProtected();
        ITypeDefinitionFilterSequence AreNotProtected();

        ITypeDefinitionFilterSequence AreFileScoped();
        ITypeDefinitionFilterSequence AreNotFileScoped();
    }
}
