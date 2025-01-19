namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypeDefinitionFilters
    {
        public ITypesFilterPostConditions ArePartial()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Partial);
            return this;
        }

        public ITypesFilterPostConditions AreNotPartial()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotPartial);
            return this;
        }

        public ITypesFilterPostConditions AreSealed()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Sealed);
            return this;
        }

        public ITypesFilterPostConditions AreNotSealed()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotSealed);
            return this;
        }

        public ITypesFilterPostConditions AreNested()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Nested);
            return this;
        }

        public ITypesFilterPostConditions AreNotNested()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotNested);
            return this;
        }

        public ITypesFilterPostConditions AreStatic()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Static);
            return this;
        }

        public ITypesFilterPostConditions AreNotStatic()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotStatic);
            return this;
        }
    }
}
