namespace ArchGuard.Library.Type.Assertions
{
    using ArchGuard.Library.Type.Assertions;

    public sealed partial class TypesAssertion
    {
        public ITypesAssertionPostCondition BePartial()
        {
            _context.AddPredicate(TypePredicate.Partial);
            return this;
        }

        public ITypesAssertionPostCondition NotBePartial()
        {
            _context.AddPredicate(TypePredicate.NotPartial);
            return this;
        }

        public ITypesAssertionPostCondition BeSealed()
        {
            _context.AddPredicate(TypePredicate.Sealed);
            return this;
        }

        public ITypesAssertionPostCondition NotBeSealed()
        {
            _context.AddPredicate(TypePredicate.NotSealed);
            return this;
        }

        public ITypesAssertionPostCondition BeNested()
        {
            _context.AddPredicate(TypePredicate.Nested);
            return this;
        }

        public ITypesAssertionPostCondition NotBeNested()
        {
            _context.AddPredicate(TypePredicate.NotNested);
            return this;
        }

        public ITypesAssertionPostCondition BeStatic()
        {
            _context.AddPredicate(TypePredicate.Static);
            return this;
        }

        public ITypesAssertionPostCondition NotBeStatic()
        {
            _context.AddPredicate(TypePredicate.NotStatic);
            return this;
        }
    }
}
