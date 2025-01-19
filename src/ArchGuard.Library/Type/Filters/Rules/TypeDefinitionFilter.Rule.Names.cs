namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypeDefinitionFilter
    {
        public ITypeDefinitionFilterSequence HaveName(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveName(name));
            return this;
        }

        public ITypeDefinitionFilterSequence HaveNameMatching(params string[] regexes)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveNameMatching(regexes));
            return this;
        }

        public ITypeDefinitionFilterSequence HaveNameNotMatching(params string[] regexes)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveNameNotMatching(regexes));
            return this;
        }

        public ITypeDefinitionFilterSequence HaveFullName(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveFullName(name));
            return this;
        }

        public ITypeDefinitionFilterSequence HaveFullNameMatching(params string[] regexes)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveFullNameMatching(regexes));
            return this;
        }

        public ITypeDefinitionFilterSequence HaveFullNameNotMatching(params string[] regexes)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveFullNameNotMatching(regexes));
            return this;
        }

        public ITypeDefinitionFilterSequence HaveNameStartingWith(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveNameStartingWith(name));
            return this;
        }

        public ITypeDefinitionFilterSequence HaveNameEndingWith(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveNameEndingWith(name));
            return this;
        }
    }
}
