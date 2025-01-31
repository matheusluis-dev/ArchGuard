namespace ArchGuard
{
    public interface IMethodFilterSequence : IGetMethods, IMethodShould
    {
        IMethodFilterRule And { get; }
        IMethodFilterRule Or { get; }
    }
}
