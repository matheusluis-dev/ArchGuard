namespace ArchGuard
{
    public partial interface IFieldFilterRule
    {
        IFieldFilterSequence ArePublic();
        IFieldFilterSequence AreNotPublic();

        IFieldFilterSequence AreInternal();
        IFieldFilterSequence AreNotInternal();

        IFieldFilterSequence AreProtected();
        IFieldFilterSequence AreNotProtected();

        IFieldFilterSequence ArePrivate();
        IFieldFilterSequence AreNotPrivate();
    }
}
