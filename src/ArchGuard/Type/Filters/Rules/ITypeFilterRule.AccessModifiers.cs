namespace ArchGuard
{
    public partial interface ITypeFilterRule
    {
        ITypeFilterSequence ArePublic();
        ITypeFilterSequence AreNotPublic();

        ITypeFilterSequence AreInternal();
        ITypeFilterSequence AreNotInternal();

        ITypeFilterSequence ArePrivate();
        ITypeFilterSequence AreNotPrivate();

        ITypeFilterSequence AreProtected();
        ITypeFilterSequence AreNotProtected();

        ITypeFilterSequence AreFileLocal();
        ITypeFilterSequence AreNotFileLocal();
    }
}
