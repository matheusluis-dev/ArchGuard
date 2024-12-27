namespace ArchGuard.Library.Types.Filters;

using ArchGuard.Library.Types.Filters.PostConditions.Interfaces;

public sealed partial class TypesFilter
{
    public ITypesFilterConditions That()
    {
        return this;
    }

    public ITypesFilterPostConditions That(
        Func<ITypesFilterConditions, ITypesFilterPostConditions> filter
    )
    {
        ArgumentNullException.ThrowIfNull(filter);
        filter(this);

        return this;
    }

    public IEnumerable<Type> GetTypes()
    {
        return _context.Types;
    }
}
