namespace ArchGuard.Library.Types.Filters.Interfaces;

public interface ITypesFilterPostCondition
{
    ITypesFilterCondition And();
    ITypesFilterCondition Or();

    IEnumerable<Type> GetTypes();
}
