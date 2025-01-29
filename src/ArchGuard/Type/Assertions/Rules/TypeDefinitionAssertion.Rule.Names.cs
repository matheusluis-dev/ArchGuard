namespace ArchGuardType.Assertions
{
    using ArchGuardType.Assertions.Sequences;
    using ArchGuardType.Predicates;

    public sealed partial class TypeDefinitionAssertion
    {
        public ITypeDefinitionAssertionSequence HaveName(params string[] names)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveName(names));
            return this;
        }

        public ITypeDefinitionAssertionSequence HaveFullName(params string[] names)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveFullName(names));
            return this;
        }

        public ITypeDefinitionAssertionSequence HaveNameStartingWith(params string[] names)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveNameStartingWith(names));
            return this;
        }

        public ITypeDefinitionAssertionSequence HaveNameEndingWith(params string[] names)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveNameEndingWith(names));
            return this;
        }
    }
}
