namespace ArchGuard
{
    using ArchGuard;

    public sealed partial class TypeFilter
    {
        public ITypeFilterSequence HaveName(params string[] name)
        {
            _context.AddPredicate(TypePredicate.HaveName(name));
            return this;
        }

        public ITypeFilterSequence HaveNameMatching(params string[] regexes)
        {
            _context.AddPredicate(TypePredicate.HaveNameMatching(regexes));
            return this;
        }

        public ITypeFilterSequence HaveNameNotMatching(params string[] regexes)
        {
            _context.AddPredicate(TypePredicate.HaveNameNotMatching(regexes));
            return this;
        }

        public ITypeFilterSequence HaveFullName(params string[] name)
        {
            _context.AddPredicate(TypePredicate.HaveFullName(name));
            return this;
        }

        public ITypeFilterSequence HaveFullNameMatching(params string[] regexes)
        {
            _context.AddPredicate(TypePredicate.HaveFullNameMatching(regexes));
            return this;
        }

        public ITypeFilterSequence HaveFullNameNotMatching(params string[] regexes)
        {
            _context.AddPredicate(TypePredicate.HaveFullNameNotMatching(regexes));
            return this;
        }

        public ITypeFilterSequence HaveNameStartingWith(params string[] name)
        {
            _context.AddPredicate(TypePredicate.HaveNameStartingWith(name));
            return this;
        }

        public ITypeFilterSequence HaveNameEndingWith(params string[] name)
        {
            _context.AddPredicate(TypePredicate.HaveNameEndingWith(name));
            return this;
        }
    }
}
