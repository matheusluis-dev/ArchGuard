namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Filters;
    using static ArchGuard.Library.Type.RulesContext;

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

        public static ITypesFilterStart Create(TypesFilterContext context)
        {
            return new TypesFilter(context);
        }
    }
}
