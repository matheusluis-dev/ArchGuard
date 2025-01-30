namespace ArchGuard
{
    public interface ITypeFilterEntryPoint : IGetTypes
    {
        ITypeFilterRule That { get; }
    }
}
