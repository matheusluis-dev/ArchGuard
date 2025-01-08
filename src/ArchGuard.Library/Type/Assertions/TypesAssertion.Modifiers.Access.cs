namespace ArchGuard.Library.Type.Assertions
{
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesAssertion
    {
        public ITypesAssertionPostCondition BePublic()
        {
            _context.AddPredicate(TypeSpecPredicate.Public);
            return this;
        }

        public ITypesAssertionPostCondition NotBePublic()
        {
            _context.AddPredicate(TypeSpecPredicate.NotPublic);
            return this;
        }

        public ITypesAssertionPostCondition BeInternal()
        {
            _context.AddPredicate(TypeSpecPredicate.Internal);
            return this;
        }

        public ITypesAssertionPostCondition NotBeInternal()
        {
            _context.AddPredicate(TypeSpecPredicate.NotInternal);
            return this;
        }

        public ITypesAssertionPostCondition BePrivate()
        {
            _context.AddPredicate(TypeSpecPredicate.Private);
            return this;
        }

        public ITypesAssertionPostCondition NotBePrivate()
        {
            _context.AddPredicate(TypeSpecPredicate.NotPrivate);
            return this;
        }

        public ITypesAssertionPostCondition BeProtected()
        {
            _context.AddPredicate(TypeSpecPredicate.Protected);
            return this;
        }

        public ITypesAssertionPostCondition NotBeProtected()
        {
            _context.AddPredicate(TypeSpecPredicate.NotProtected);
            return this;
        }

#if NET7_0_OR_GREATER
        public ITypesAssertionPostCondition BeFileScoped()
        {
            _context.AddPredicate(TypeSpecPredicate.FileScoped);
            return this;
        }

        public ITypesAssertionPostCondition NotBeFileScoped()
        {
            _context.AddPredicate(TypeSpecPredicate.NotFileScoped);
            return this;
        }
#endif
    }
}
