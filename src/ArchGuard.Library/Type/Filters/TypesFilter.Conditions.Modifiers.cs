namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions ArePartial()
        {
            _context.AddPredicate(TypePredicate.Partial);
            return this;
        }

        public ITypesFilterPostConditions AreNotPartial()
        {
            _context.AddPredicate(TypePredicate.NotPartial);
            return this;
        }

        public ITypesFilterPostConditions AreSealed()
        {
            _context.AddPredicate(TypePredicate.Sealed);
            return this;
        }

        public ITypesFilterPostConditions AreNotSealed()
        {
            _context.AddPredicate(TypePredicate.NotSealed);
            return this;
        }

        public ITypesFilterPostConditions AreNested()
        {
            _context.AddPredicate(TypePredicate.Nested);
            return this;
        }

        public ITypesFilterPostConditions AreNotNested()
        {
            _context.AddPredicate(TypePredicate.NotNested);
            return this;
        }

        public ITypesFilterPostConditions AreStatic()
        {
            _context.AddPredicate(TypePredicate.Static);
            return this;
        }

        public ITypesFilterPostConditions AreNotStatic()
        {
            _context.AddPredicate(TypePredicate.NotStatic);
            return this;
        }
    }
}
