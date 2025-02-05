namespace ArchGuard
{
    public sealed partial class FieldFilter
    {
        public IFieldFilterSequence ArePublic()
        {
            _context.AddPredicate(FieldPredicate.Public);
            return this;
        }

        public IFieldFilterSequence AreNotPublic()
        {
            _context.AddPredicate(FieldPredicate.NotPublic);
            return this;
        }

        public IFieldFilterSequence AreInternal()
        {
            _context.AddPredicate(FieldPredicate.Internal);
            return this;
        }

        public IFieldFilterSequence AreNotInternal()
        {
            _context.AddPredicate(FieldPredicate.NotInternal);
            return this;
        }

        public IFieldFilterSequence AreProtected()
        {
            _context.AddPredicate(FieldPredicate.Protected);
            return this;
        }

        public IFieldFilterSequence AreNotProtected()
        {
            _context.AddPredicate(FieldPredicate.NotProtected);
            return this;
        }

        public IFieldFilterSequence ArePrivate()
        {
            _context.AddPredicate(FieldPredicate.Private);
            return this;
        }

        public IFieldFilterSequence AreNotPrivate()
        {
            _context.AddPredicate(FieldPredicate.NotPrivate);
            return this;
        }
    }
}
