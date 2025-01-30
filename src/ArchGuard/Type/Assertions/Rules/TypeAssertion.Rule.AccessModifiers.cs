namespace ArchGuard
{
    using ArchGuardType.Predicates;

    public sealed partial class TypeAssertion
    {
        public ITypeAssertionSequence BePublic()
        {
            _context.AddPredicate(TypePredicate.Public);
            return this;
        }

        public ITypeAssertionSequence NotBePublic()
        {
            _context.AddPredicate(TypePredicate.NotPublic);
            return this;
        }

        public ITypeAssertionSequence BeInternal()
        {
            _context.AddPredicate(TypePredicate.Internal);
            return this;
        }

        public ITypeAssertionSequence NotBeInternal()
        {
            _context.AddPredicate(TypePredicate.NotInternal);
            return this;
        }

        public ITypeAssertionSequence BePrivate()
        {
            _context.AddPredicate(TypePredicate.Private);
            return this;
        }

        public ITypeAssertionSequence NotBePrivate()
        {
            _context.AddPredicate(TypePredicate.NotPrivate);
            return this;
        }

        public ITypeAssertionSequence BeProtected()
        {
            _context.AddPredicate(TypePredicate.Protected);
            return this;
        }

        public ITypeAssertionSequence NotBeProtected()
        {
            _context.AddPredicate(TypePredicate.NotProtected);
            return this;
        }

        public ITypeAssertionSequence BeFileScoped()
        {
            _context.AddPredicate(TypePredicate.FileScoped);
            return this;
        }

        public ITypeAssertionSequence NotBeFileScoped()
        {
            _context.AddPredicate(TypePredicate.NotFileScoped);
            return this;
        }
    }
}
