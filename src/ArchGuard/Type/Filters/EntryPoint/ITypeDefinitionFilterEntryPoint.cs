using ArchGuardType.Filters;

namespace ArchGuard.Type.Filters.EntryPoint
{
    using ArchGuard.Type.Common;

    public interface ITypeDefinitionFilterEntryPoint : IGetTypes
    {
        ITypeDefinitionFilterRule That { get; }
    }
}
