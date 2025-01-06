namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions ArePartial()
        {
            _context.ApplyFilter(TypePredicate.Partial);
            return this;
        }

        public ITypesFilterPostConditions AreNotPartial()
        {
            _context.ApplyFilter(TypePredicate.NotPartial);
            return this;
        }

        public ITypesFilterPostConditions AreSealed()
        {
            _context.ApplyFilter(TypePredicate.Sealed);
            return this;
        }

        public ITypesFilterPostConditions AreNotSealed()
        {
            _context.ApplyFilter(TypePredicate.NotSealed);
            return this;
        }

        public ITypesFilterPostConditions AreNested()
        {
            _context.ApplyFilter(TypePredicate.Nested);
            return this;
        }

        public ITypesFilterPostConditions AreNotNested()
        {
            _context.ApplyFilter(TypePredicate.NotNested);
            return this;
        }

        public ITypesFilterPostConditions AreStatic()
        {
            _context.ApplyFilter(TypePredicate.Static);
            return this;
        }

        public ITypesFilterPostConditions AreNotStatic()
        {
            _context.ApplyFilter(TypePredicate.NotStatic);
            return this;
        }
    }
}
