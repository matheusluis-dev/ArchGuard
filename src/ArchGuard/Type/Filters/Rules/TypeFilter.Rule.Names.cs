namespace ArchGuard
{
    public sealed partial class TypeFilter
    {
        public ITypeFilterSequence HaveName(params string[] names)
        {
            _context.AddPredicate(TypePredicate.HaveName(names));
            return this;
        }

        public ITypeFilterSequence HaveNameMatching(params string[] regexes)
        {
            _context.AddPredicate(TypePredicate.HaveNameMatching(regexes));
            return this;
        }

        public ITypeFilterSequence NotHaveNameMatching(params string[] regexes)
        {
            _context.AddPredicate(TypePredicate.HaveNameNotMatching(regexes));
            return this;
        }

        public ITypeFilterSequence HaveFullName(params string[] names)
        {
            _context.AddPredicate(TypePredicate.HaveFullName(names));
            return this;
        }

        public ITypeFilterSequence HaveFullNameMatching(params string[] regexes)
        {
            _context.AddPredicate(TypePredicate.HaveFullNameMatching(regexes));
            return this;
        }

        public ITypeFilterSequence NotHaveFullNameMatching(params string[] regexes)
        {
            _context.AddPredicate(TypePredicate.HaveFullNameNotMatching(regexes));
            return this;
        }

        public ITypeFilterSequence HaveNameStartingWith(params string[] names)
        {
            _context.AddPredicate(TypePredicate.HaveNameStartingWith(names));
            return this;
        }

        public ITypeFilterSequence NotHaveNameStartingWith(params string[] names)
        {
            _context.AddPredicate(TypePredicate.NotHaveNameStartingWith(names));
            return this;
        }

        public ITypeFilterSequence HaveNameEndingWith(params string[] names)
        {
            _context.AddPredicate(TypePredicate.HaveNameEndingWith(names));
            return this;
        }

        public ITypeFilterSequence NotHaveNameEndingWith(params string[] names)
        {
            _context.AddPredicate(TypePredicate.NotHaveNameEndingWith(names));
            return this;
        }
    }
}
