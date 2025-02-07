namespace ArchGuard
{
    public interface IPropertyFilterSequence : IGetProperties, IPropertyShould
    {
        IPropertyFilterRule And { get; }
        IPropertyFilterRule Or { get; }
    }
}
