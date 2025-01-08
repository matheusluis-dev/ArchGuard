namespace ArchGuard.Library.Type.Assertions
{
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesAssertion
    {
        public ITypesAssertionPostCondition BePartial()
        {
            _context.AddPredicate(TypeSpecPredicate.Partial);
            return this;
        }

        public ITypesAssertionPostCondition NotBePartial()
        {
            _context.AddPredicate(TypeSpecPredicate.NotPartial);
            return this;
        }

        public ITypesAssertionPostCondition BeSealed()
        {
            _context.AddPredicate(TypeSpecPredicate.Sealed);
            return this;
        }

        public ITypesAssertionPostCondition NotBeSealed()
        {
            _context.AddPredicate(TypeSpecPredicate.NotSealed);
            return this;
        }

        public ITypesAssertionPostCondition BeNested()
        {
            _context.AddPredicate(TypeSpecPredicate.Nested);
            return this;
        }

        public ITypesAssertionPostCondition NotBeNested()
        {
            _context.AddPredicate(TypeSpecPredicate.NotNested);
            return this;
        }

        public ITypesAssertionPostCondition BeStatic()
        {
            _context.AddPredicate(TypeSpecPredicate.Static);
            return this;
        }

        public ITypesAssertionPostCondition NotBeStatic()
        {
            _context.AddPredicate(TypeSpecPredicate.NotStatic);
            return this;
        }
    }
}
