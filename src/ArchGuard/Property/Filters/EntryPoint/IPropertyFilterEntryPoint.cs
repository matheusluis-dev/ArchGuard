namespace ArchGuard
{
    public interface IPropertyFilterEntryPoint : IGetProperties, IPropertyShould
    {
        IPropertyFilterRule That { get; }
    }
}
