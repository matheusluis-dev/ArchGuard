namespace ArchGuard
{
    public interface IFieldFilterSequence : IGetFields, IFieldShould
    {
        IFieldFilterRule And { get; }
        IFieldFilterRule Or { get; }
    }
}
