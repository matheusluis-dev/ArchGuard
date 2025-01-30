namespace ArchGuard
{
    using ArchGuardType.Predicates;

    public sealed partial class TypeDefinitionAssertion
    {
        public ITypeDefinitionAssertionSequence BePartial()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Partial);
            return this;
        }

        public ITypeDefinitionAssertionSequence NotBePartial()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotPartial);
            return this;
        }

        public ITypeDefinitionAssertionSequence BeSealed()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Sealed);
            return this;
        }

        public ITypeDefinitionAssertionSequence NotBeSealed()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotSealed);
            return this;
        }

        public ITypeDefinitionAssertionSequence BeNested()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Nested);
            return this;
        }

        public ITypeDefinitionAssertionSequence NotBeNested()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotNested);
            return this;
        }

        public ITypeDefinitionAssertionSequence BeStatic()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Static);
            return this;
        }

        public ITypeDefinitionAssertionSequence NotBeStatic()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotStatic);
            return this;
        }

        public ITypeDefinitionAssertionSequence BeAbstract()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Abstract);
            return this;
        }

        public ITypeDefinitionAssertionSequence NotBeAbstract()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotAbstract);
            return this;
        }
    }
}
