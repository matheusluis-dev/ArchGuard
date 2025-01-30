namespace ArchGuard
{
    public partial interface ITypeFilterRule
    {
        ITypeFilterSequence ArePartial();
        ITypeFilterSequence AreNotPartial();

        ITypeFilterSequence AreSealed();
        ITypeFilterSequence AreNotSealed();

        ITypeFilterSequence AreNested();
        ITypeFilterSequence AreNotNested();

        ITypeFilterSequence AreStatic();
        ITypeFilterSequence AreNotStatic();

        ITypeFilterSequence AreAbstract();
        ITypeFilterSequence AreNotAbstract();
    }
}
