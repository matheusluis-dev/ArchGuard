namespace ArchGuard.Library.Types.Filter;

public sealed partial class TypesFilter
{
    public ITypesFilterCondition And()
    {
        return this;
    }

    public ITypesFilterCondition Or()
    {
        return this;
    }
}
