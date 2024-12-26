namespace ArchGuard.Library.Types.Filter;

public interface ITypesFilterPostCondition
{
    ITypesFilterCondition And();
    ITypesFilterCondition Or();

    IEnumerable<Type> GetTypes();
}
