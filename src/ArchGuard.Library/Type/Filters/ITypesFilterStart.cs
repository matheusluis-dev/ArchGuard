namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type;
    using ArchGuard.Library.Type.Filters.Conditions.Interfaces;

    public interface ITypesFilterStart : IGetTypes
    {
        ITypesFilterConditions That { get; }
    }
}
