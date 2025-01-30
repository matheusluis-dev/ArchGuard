namespace ArchGuard
{
    public interface IMethodFilterEntryPoint : IGetMethods
    {
        IMethodFilterRule That { get; }
    }
}
