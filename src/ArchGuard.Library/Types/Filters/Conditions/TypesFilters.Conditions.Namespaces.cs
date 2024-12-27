namespace ArchGuard.Library.Types.Filters;

public sealed partial class TypesFilter
{
    public ITypesFilterPostConditions ResideInNamespace(string name)
    {
        _context.ApplyFilter(f =>
            f.Namespace is not null && f.Namespace.Equals(name, StringComparison.Ordinal)
        );

        return this;
    }

    public ITypesFilterPostConditions ResideInNamespace(string name, StringComparison comparer)
    {
        _context.ApplyFilter(f => f.Namespace is not null && f.Namespace.Equals(name, comparer));

        return this;
    }

    public ITypesFilterPostConditions NotResideInNamespace(string name)
    {
        _context.ApplyFilter(f =>
            f.Namespace is not null && !f.Namespace.Equals(name, StringComparison.Ordinal)
        );

        return this;
    }

    public ITypesFilterPostConditions NotResideInNamespace(string name, StringComparison comparer)
    {
        _context.ApplyFilter(f => f.Namespace is not null && !f.Namespace.Equals(name, comparer));

        return this;
    }
}
