namespace ArchGuard.Library.Type.Assertions
{
    public sealed partial class TypesAssertion
    {
        public ITypesAssertionPostCondition BePublic()
        {
            _context.ApplyAssertion(TypePredicates.Public);
            return this;
        }

        public ITypesAssertionPostCondition BeNotPublic()
        {
            _context.ApplyAssertion(TypePredicates.NotPublic);
            return this;
        }

        public ITypesAssertionPostCondition BeInternal()
        {
            _context.ApplyAssertion(TypePredicates.Internal);
            return this;
        }

        public ITypesAssertionPostCondition BeNotInternal()
        {
            _context.ApplyAssertion(TypePredicates.NotInternal);
            return this;
        }

        public ITypesAssertionPostCondition BePrivate()
        {
            _context.ApplyAssertion(TypePredicates.Private);
            return this;
        }

        public ITypesAssertionPostCondition BeNotPrivate()
        {
            _context.ApplyAssertion(TypePredicates.NotPrivate);
            return this;
        }

        public ITypesAssertionPostCondition BeProtected()
        {
            _context.ApplyAssertion(TypePredicates.Protected);
            return this;
        }

        public ITypesAssertionPostCondition BeNotProtected()
        {
            _context.ApplyAssertion(TypePredicates.NotProtected);
            return this;
        }

#if NET7_0_OR_GREATER
        public ITypesAssertionPostCondition BeFileScoped()
        {
            _context.ApplyAssertion(TypePredicates.FileScoped);
            return this;
        }

        public ITypesAssertionPostCondition BeNotFileScoped()
        {
            _context.ApplyAssertion(TypePredicates.NotFileScoped);
            return this;
        }
#endif
    }
}
