namespace ArchGuard
{
    using ArchGuardType.Predicates;

    public sealed partial class TypeDefinitionAssertion
    {
        public ITypeDefinitionAssertionSequence HaveName(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveName(name));
            return this;
        }

        public ITypeDefinitionAssertionSequence HaveNameMatching(params string[] regexes)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveNameMatching(regexes));
            return this;
        }

        public ITypeDefinitionAssertionSequence HaveNameNotMatching(params string[] regexes)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveNameNotMatching(regexes));
            return this;
        }

        public ITypeDefinitionAssertionSequence HaveFullName(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveFullName(name));
            return this;
        }

        public ITypeDefinitionAssertionSequence HaveFullNameMatching(params string[] regexes)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveFullNameMatching(regexes));
            return this;
        }

        public ITypeDefinitionAssertionSequence HaveFullNameNotMatching(params string[] regexes)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveFullNameNotMatching(regexes));
            return this;
        }

        public ITypeDefinitionAssertionSequence HaveNameStartingWith(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveNameStartingWith(name));
            return this;
        }

        public ITypeDefinitionAssertionSequence HaveNameEndingWith(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveNameEndingWith(name));
            return this;
        }
    }
}
