namespace ArchGuard.Library.Type.Assertions
{
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesAssertion
    {
        public ITypesAssertionPostCondition BePublic()
        {
            _context.AddPredicate(TypePredicate.Public);
            return this;
        }

        public ITypesAssertionPostCondition NotBePublic()
        {
            _context.AddPredicate(TypePredicate.NotPublic);
            return this;
        }

        public ITypesAssertionPostCondition BeInternal()
        {
            _context.AddPredicate(TypePredicate.Internal);
            return this;
        }

        public ITypesAssertionPostCondition NotBeInternal()
        {
            _context.AddPredicate(TypePredicate.NotInternal);
            return this;
        }

        public ITypesAssertionPostCondition BePrivate()
        {
            _context.AddPredicate(TypePredicate.Private);
            return this;
        }

        public ITypesAssertionPostCondition NotBePrivate()
        {
            _context.AddPredicate(TypePredicate.NotPrivate);
            return this;
        }

        public ITypesAssertionPostCondition BeProtected()
        {
            _context.AddPredicate(TypePredicate.Protected);
            return this;
        }

        public ITypesAssertionPostCondition NotBeProtected()
        {
            _context.AddPredicate(TypePredicate.NotProtected);
            return this;
        }

        public ITypesAssertionPostCondition BeFileScoped()
        {
            _context.AddPredicate(TypePredicate.FileScoped);
            return this;
        }

        public ITypesAssertionPostCondition NotBeFileScoped()
        {
            _context.AddPredicate(TypePredicate.NotFileScoped);
            return this;
        }
    }
}
