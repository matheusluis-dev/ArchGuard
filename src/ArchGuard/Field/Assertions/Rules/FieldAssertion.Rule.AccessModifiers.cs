namespace ArchGuard
{
    public sealed partial class FieldAssertion
    {
        public IFieldAssertionSequence BePublic()
        {
            _context.AddPredicate(FieldPredicate.Public);
            return this;
        }

        public IFieldAssertionSequence NotBePublic()
        {
            _context.AddPredicate(FieldPredicate.NotPublic);
            return this;
        }

        public IFieldAssertionSequence BeInternal()
        {
            _context.AddPredicate(FieldPredicate.Internal);
            return this;
        }

        public IFieldAssertionSequence NotBeInternal()
        {
            _context.AddPredicate(FieldPredicate.NotInternal);
            return this;
        }

        public IFieldAssertionSequence BeProtected()
        {
            _context.AddPredicate(FieldPredicate.Protected);
            return this;
        }

        public IFieldAssertionSequence NotBeProtected()
        {
            _context.AddPredicate(FieldPredicate.NotProtected);
            return this;
        }

        public IFieldAssertionSequence BePrivate()
        {
            _context.AddPredicate(FieldPredicate.Private);
            return this;
        }

        public IFieldAssertionSequence NotBePrivate()
        {
            _context.AddPredicate(FieldPredicate.NotPrivate);
            return this;
        }
    }
}
