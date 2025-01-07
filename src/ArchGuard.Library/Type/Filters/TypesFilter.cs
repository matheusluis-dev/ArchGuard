namespace ArchGuard.Library.Type.Filters
{
    using System;
    using ArchGuard.Library.Type.Filters.Conditions.Interfaces;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public sealed partial class TypesFilter
        : ITypesFilterStart,
            ITypesFilterConditions,
            ITypesFilterPostConditions
    {
        private readonly TypesFilterContext _context;

        private readonly StringComparison _comparison = StringComparison.CurrentCulture;

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
