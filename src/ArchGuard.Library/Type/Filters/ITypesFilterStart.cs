using ArchGuard.Library.Type.Filters;

namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type;

    public interface ITypesFilterStart : IGetTypes
    {
        ITypesFilterConditions That { get; }
    }
}
