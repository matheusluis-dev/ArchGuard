namespace ArchGuard.Library.Types.Filters;

public sealed partial class TypesFilter
{
    public ITypesFilterCondition And()
    {
        _context.And();
        return this;
    }

    public ITypesFilterCondition Or()
    {
        _context.Or();
        return this;
    }
}
