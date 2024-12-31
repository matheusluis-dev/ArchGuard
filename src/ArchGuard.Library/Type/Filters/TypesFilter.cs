namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Filters.Common.Interfaces;
    using ArchGuard.Library.Type.Filters.Conditions.Interfaces;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

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
