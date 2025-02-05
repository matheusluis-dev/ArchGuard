namespace ArchGuard
{
    public partial interface IFieldFilterRule
    {
        IFieldFilterSequence AreStatic();
        IFieldFilterSequence AreNotStatic();

        IFieldFilterSequence AreConst();
        IFieldFilterSequence AreNotConst();

        IFieldFilterSequence AreReadonly();
        IFieldFilterSequence AreNotReadonly();
    }
}
