namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions ArePartial()
        {
            _context.AddPredicate(TypeSpecPredicate.Partial);
            return this;
        }

        public ITypesFilterPostConditions AreNotPartial()
        {
            _context.AddPredicate(TypeSpecPredicate.NotPartial);
            return this;
        }

        public ITypesFilterPostConditions AreSealed()
        {
            _context.AddPredicate(TypeSpecPredicate.Sealed);
            return this;
        }

        public ITypesFilterPostConditions AreNotSealed()
        {
            _context.AddPredicate(TypeSpecPredicate.NotSealed);
            return this;
        }

        public ITypesFilterPostConditions AreNested()
        {
            _context.AddPredicate(TypeSpecPredicate.Nested);
            return this;
        }

        public ITypesFilterPostConditions AreNotNested()
        {
            _context.AddPredicate(TypeSpecPredicate.NotNested);
            return this;
        }

        public ITypesFilterPostConditions AreStatic()
        {
            _context.AddPredicate(TypeSpecPredicate.Static);
            return this;
        }

        public ITypesFilterPostConditions AreNotStatic()
        {
            _context.AddPredicate(TypeSpecPredicate.NotStatic);
            return this;
        }
    }
}
