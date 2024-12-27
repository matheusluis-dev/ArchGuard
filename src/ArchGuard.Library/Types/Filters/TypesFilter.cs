namespace ArchGuard.Library.Types.Filters;

using ArchGuard.Library.Types.Filters.Interfaces;

public sealed partial class TypesFilter : ITypesFilterCondition, ITypesFilterPostCondition
{
    private readonly TypesFilterContext _context;

    private TypesFilter(TypesFilterContext context)
    {
        _context = context;
    }

    public static ITypesFilterCondition That(TypesFilterContext context)
    {
        return new TypesFilter(context);
    }

    public IEnumerable<Type> GetTypes()
    {
        return _context.Types;
    }
}
