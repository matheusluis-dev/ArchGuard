namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Common;

    public interface ITypeDefinitionFilterEntryPoint : IGetTypes
    {
        ITypeDefinitionFilterRule That { get; }
    }
}
