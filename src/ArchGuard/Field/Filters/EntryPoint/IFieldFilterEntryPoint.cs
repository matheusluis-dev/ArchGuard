namespace ArchGuard
{
    public interface IFieldFilterEntryPoint : IGetFields, IFieldShould
    {
        IFieldFilterRule That { get; }
    }
}
