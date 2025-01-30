namespace ArchGuard
{
    using ArchGuardType.Predicates;

    public sealed partial class TypeAssertion
    {
        public ITypeAssertionSequence BePartial()
        {
            _context.AddPredicate(TypePredicate.Partial);
            return this;
        }

        public ITypeAssertionSequence NotBePartial()
        {
            _context.AddPredicate(TypePredicate.NotPartial);
            return this;
        }

        public ITypeAssertionSequence BeSealed()
        {
            _context.AddPredicate(TypePredicate.Sealed);
            return this;
        }

        public ITypeAssertionSequence NotBeSealed()
        {
            _context.AddPredicate(TypePredicate.NotSealed);
            return this;
        }

        public ITypeAssertionSequence BeNested()
        {
            _context.AddPredicate(TypePredicate.Nested);
            return this;
        }

        public ITypeAssertionSequence NotBeNested()
        {
            _context.AddPredicate(TypePredicate.NotNested);
            return this;
        }

        public ITypeAssertionSequence BeStatic()
        {
            _context.AddPredicate(TypePredicate.Static);
            return this;
        }

        public ITypeAssertionSequence NotBeStatic()
        {
            _context.AddPredicate(TypePredicate.NotStatic);
            return this;
        }

        public ITypeAssertionSequence BeAbstract()
        {
            _context.AddPredicate(TypePredicate.Abstract);
            return this;
        }

        public ITypeAssertionSequence NotBeAbstract()
        {
            _context.AddPredicate(TypePredicate.NotAbstract);
            return this;
        }
    }
}
