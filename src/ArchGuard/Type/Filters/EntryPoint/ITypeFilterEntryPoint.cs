namespace ArchGuard
{
    public interface ITypeFilterEntryPoint : IGetTypes, ISwitchToVerify
    {
        ITypeFilterRule That { get; }
    }
}
