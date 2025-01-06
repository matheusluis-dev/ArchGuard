namespace ArchGuard.Library.Type.Assertions
{
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesAssertion
    {
        public ITypesAssertionPostCondition BePublic()
        {
            _context.ApplyAssertion(TypePredicate.Public);
            return this;
        }

        public ITypesAssertionPostCondition BeNotPublic()
        {
            _context.ApplyAssertion(TypePredicate.NotPublic);
            return this;
        }

        public ITypesAssertionPostCondition BeInternal()
        {
            _context.ApplyAssertion(TypePredicate.Internal);
            return this;
        }

        public ITypesAssertionPostCondition BeNotInternal()
        {
            _context.ApplyAssertion(TypePredicate.NotInternal);
            return this;
        }

        public ITypesAssertionPostCondition BePrivate()
        {
            _context.ApplyAssertion(TypePredicate.Private);
            return this;
        }

        public ITypesAssertionPostCondition BeNotPrivate()
        {
            _context.ApplyAssertion(TypePredicate.NotPrivate);
            return this;
        }

        public ITypesAssertionPostCondition BeProtected()
        {
            _context.ApplyAssertion(TypePredicate.Protected);
            return this;
        }

        public ITypesAssertionPostCondition BeNotProtected()
        {
            _context.ApplyAssertion(TypePredicate.NotProtected);
            return this;
        }

#if NET7_0_OR_GREATER
        public ITypesAssertionPostCondition BeFileScoped()
        {
            _context.ApplyAssertion(TypePredicate.FileScoped);
            return this;
        }

        public ITypesAssertionPostCondition BeNotFileScoped()
        {
            _context.ApplyAssertion(TypePredicate.NotFileScoped);
            return this;
        }
#endif
    }
}
