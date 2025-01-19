namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type;

    public interface ITypeDefinitionFilterEntryPoint : IGetTypes
    {
        ITypeDefinitionFilterRule That { get; }
    }
}
