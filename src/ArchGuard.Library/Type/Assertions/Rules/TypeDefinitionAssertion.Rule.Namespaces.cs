namespace ArchGuard.Library.Type.Assertions
{
    using ArchGuard.Library.Type.Assertions.Sequences;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypeDefinitionAssertion
    {
        public ITypeDefinitionAssertionSequence ResideInNamespace(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.ResideInNamespace(name));
            return this;
        }

        public ITypeDefinitionAssertionSequence ResideInNamespaceContaining(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.ResideInNamespaceContaining(name));
            return this;
        }

        public ITypeDefinitionAssertionSequence ResideInNamespaceEndingWith(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.ResideInNamespaceEndingWith(name));
            return this;
        }

        public ITypeDefinitionAssertionSequence NotResideInNamespace(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.DoNotResideInNamespace(name));
            return this;
        }

        public ITypeDefinitionAssertionSequence NotResideInNamespaceContaining(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.DoNotResideInNamespaceContaining(name));
            return this;
        }

        public ITypeDefinitionAssertionSequence NotResideInNamespaceEndingWith(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.DoNotResideInNamespaceEndingWith(name));
            return this;
        }
    }
}
