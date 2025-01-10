namespace ArchGuard.Roslyn.Type.Filters
{
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
}
