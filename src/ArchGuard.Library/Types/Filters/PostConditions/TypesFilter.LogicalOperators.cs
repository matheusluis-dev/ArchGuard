namespace ArchGuard.Library.Types.Filters;

public sealed partial class TypesFilter
{
    public ITypesFilterConditions And()
    {
        _context.And();
        return this;
    }

    public ITypesFilterPostConditions And(
        Func<ITypesFilterConditions, ITypesFilterPostConditions> filter
    )
    {
        ArgumentNullException.ThrowIfNull(filter);

        _context.And();
        filter(this);

        return this;
    }

    public ITypesFilterConditions Or()
    {
        _context.Or();
        return this;
    }

    public ITypesFilterPostConditions Or(
        Func<ITypesFilterConditions, ITypesFilterPostConditions> filter
    )
    {
        ArgumentNullException.ThrowIfNull(filter);

        _context.Or();
        filter(this);

        return this;
    }
}
