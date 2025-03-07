namespace ArchGuard
{
    public sealed partial class TypeAssertion
    {
        public ITypeAssertionSequence HaveName(params string[] name)
        {
            _context.AddPredicate(TypePredicate.HaveName(name));
            return this;
        }

        public ITypeAssertionSequence HaveNameMatching(params string[] regexes)
        {
            _context.AddPredicate(TypePredicate.HaveNameMatching(regexes));
            return this;
        }

        public ITypeAssertionSequence NotHaveNameMatching(params string[] regexes)
        {
            _context.AddPredicate(TypePredicate.HaveNameNotMatching(regexes));
            return this;
        }

        public ITypeAssertionSequence HaveFullName(params string[] name)
        {
            _context.AddPredicate(TypePredicate.HaveFullName(name));
            return this;
        }

        public ITypeAssertionSequence HaveFullNameMatching(params string[] regexes)
        {
            _context.AddPredicate(TypePredicate.HaveFullNameMatching(regexes));
            return this;
        }

        public ITypeAssertionSequence NotHaveFullNameMatching(params string[] regexes)
        {
            _context.AddPredicate(TypePredicate.HaveFullNameNotMatching(regexes));
            return this;
        }

        public ITypeAssertionSequence HaveNameStartingWith(params string[] name)
        {
            _context.AddPredicate(TypePredicate.HaveNameStartingWith(name));
            return this;
        }

        public ITypeAssertionSequence NotHaveNameStartingWith(params string[] names)
        {
            _context.AddPredicate(TypePredicate.NotHaveNameStartingWith(names));
            return this;
        }

        public ITypeAssertionSequence HaveNameEndingWith(params string[] name)
        {
            _context.AddPredicate(TypePredicate.HaveNameEndingWith(name));
            return this;
        }

        public ITypeAssertionSequence NotHaveNameEndingWith(params string[] names)
        {
            _context.AddPredicate(TypePredicate.NotHaveNameEndingWith(names));
            return this;
        }

        public ITypeAssertionSequence HaveNamePascalCased()
        {
            _context.AddPredicate(TypePredicate.HaveNamePascalCased);
            return this;
        }
    }
}
