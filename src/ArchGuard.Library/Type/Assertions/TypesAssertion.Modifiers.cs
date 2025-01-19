namespace ArchGuard.Library.Type.Assertions
{
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesAssertion
    {
        public ITypesAssertionPostCondition BePartial()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Partial);
            return this;
        }

        public ITypesAssertionPostCondition NotBePartial()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotPartial);
            return this;
        }

        public ITypesAssertionPostCondition BeSealed()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Sealed);
            return this;
        }

        public ITypesAssertionPostCondition NotBeSealed()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotSealed);
            return this;
        }

        public ITypesAssertionPostCondition BeNested()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Nested);
            return this;
        }

        public ITypesAssertionPostCondition NotBeNested()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotNested);
            return this;
        }

        public ITypesAssertionPostCondition BeStatic()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Static);
            return this;
        }

        public ITypesAssertionPostCondition NotBeStatic()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotStatic);
            return this;
        }
    }
}
