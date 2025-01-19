namespace ArchGuard.Library.Type.Assertions
{
    using ArchGuard.Library.Type.Assertions.Sequences;
    using ArchGuard.Library.Type.Predicates;

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
