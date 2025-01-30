namespace ArchGuard
{
    public interface ITypeFilterEntryPoint : IGetTypes, ISwitchToMethodFilter
    {
        ITypeFilterRule That { get; }
    }
}
