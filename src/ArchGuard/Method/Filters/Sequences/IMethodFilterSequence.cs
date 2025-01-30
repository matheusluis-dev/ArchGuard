namespace ArchGuard
{
    public interface IMethodFilterSequence : IGetMethods
    {
        IMethodFilterRule And { get; }
        IMethodFilterRule Or { get; }
    }
}
