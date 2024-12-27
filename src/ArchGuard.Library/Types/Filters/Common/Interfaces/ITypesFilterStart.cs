namespace ArchGuard.Library.Types.Filters.Common.Interfaces;

public interface ITypesFilterStart : IGetTypes
{
    ITypesFilterConditions That();
    ITypesFilterPostConditions That(
        Func<ITypesFilterConditions, ITypesFilterPostConditions> filter
    );
}
