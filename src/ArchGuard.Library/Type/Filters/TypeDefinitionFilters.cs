namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Contexts;
    using static ArchGuard.Library.Type.Contexts.RulesContext;

    public sealed partial class TypeDefinitionFilters
        : ITypesFilterStart,
            ITypesFilterConditions,
            ITypesFilterPostConditions
    {
        private readonly TypesFilterContext _context;

        internal TypeDefinitionFilters(TypesFilterContext context)
        {
            _context = context;
        }

        private readonly StartTypeAssertionCallback _callback;

        internal TypeDefinitionFilters(TypesFilterContext context, StartTypeAssertionCallback callback)
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
