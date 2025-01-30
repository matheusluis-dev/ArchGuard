namespace ArchGuard
{
    public interface ITypeDefinitionFilterEntryPoint : IGetTypes
    {
        ITypeDefinitionFilterRule That { get; }
    }
}
