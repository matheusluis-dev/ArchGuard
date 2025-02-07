namespace ArchGuard
{
    public interface ITypeFilterEntryPoint : IGetTypes, ISwitchToVerify, IShould
    {
        ITypeFilterRule That { get; }

        ISliceFilterRule Slice { get; }
    }
}
