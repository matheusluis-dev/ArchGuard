namespace ArchGuard
{
    public interface IMethodFilterEntryPoint : IGetMethods, IMethodShould
    {
        IMethodFilterRule That { get; }
    }
}
