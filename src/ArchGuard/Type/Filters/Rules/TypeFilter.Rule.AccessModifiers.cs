namespace ArchGuard
{
    using ArchGuard;

    public sealed partial class TypeFilter
    {
        public ITypeFilterSequence ArePublic()
        {
            _context.AddPredicate(TypePredicate.Public);
            return this;
        }

        public ITypeFilterSequence AreNotPublic()
        {
            _context.AddPredicate(TypePredicate.NotPublic);
            return this;
        }

        public ITypeFilterSequence AreInternal()
        {
            _context.AddPredicate(TypePredicate.Internal);
            return this;
        }

        public ITypeFilterSequence AreNotInternal()
        {
            _context.AddPredicate(TypePredicate.NotInternal);
            return this;
        }

        public ITypeFilterSequence ArePrivate()
        {
            _context.AddPredicate(TypePredicate.Private);
            return this;
        }

        public ITypeFilterSequence AreNotPrivate()
        {
            _context.AddPredicate(TypePredicate.NotPrivate);
            return this;
        }

        public ITypeFilterSequence AreProtected()
        {
            _context.AddPredicate(TypePredicate.Protected);
            return this;
        }

        public ITypeFilterSequence AreNotProtected()
        {
            _context.AddPredicate(TypePredicate.NotProtected);
            return this;
        }

        public ITypeFilterSequence AreFileScoped()
        {
            _context.AddPredicate(TypePredicate.FileScoped);
            return this;
        }

        public ITypeFilterSequence AreNotFileScoped()
        {
            _context.AddPredicate(TypePredicate.NotFileScoped);
            return this;
        }
    }
}
