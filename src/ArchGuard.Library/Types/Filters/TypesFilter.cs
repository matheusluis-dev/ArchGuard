namespace ArchGuard.Library.Types.Filters;

using ArchGuard.Library.Types.Filters.Common.Interfaces;

public sealed partial class TypesFilter
    : ITypesFilterStart,
        ITypesFilterConditions,
        ITypesFilterPostConditions
{
    private readonly TypesFilterContext _context;

    private TypesFilter(TypesFilterContext context)
    {
        _context = context;
    }

    public static ITypesFilterStart Create(TypesFilterContext context)
    {
        return new TypesFilter(context);
    }
}
