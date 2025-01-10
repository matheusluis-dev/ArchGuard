namespace ArchGuard.Roslyn.Type.Filters
{
    public interface ITypesFilterStart : IGetTypes
    {
        ITypesFilterConditions That { get; }
    }
}
