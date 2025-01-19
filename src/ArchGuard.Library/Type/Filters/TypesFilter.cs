namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Contexts;
    using static ArchGuard.Library.Type.Contexts.RulesContext;

    public sealed partial class TypesFilter
        : ITypesFilterStart,
            ITypesFilterConditions,
            ITypesFilterPostConditions
    {
        private readonly TypesFilterContext _context;

        internal TypesFilter(TypesFilterContext context)
        {
            _context = context;
        }

        private readonly StartTypeAssertionCallback _callback;

        internal TypesFilter(TypesFilterContext context, StartTypeAssertionCallback callback)
        {
            _context = context;
            _callback = callback;
        }

        internal ITypesFilterStart Start()
        {
            return this;
        }
    }
}
