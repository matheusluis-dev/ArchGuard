namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypeDefinitionFilter
    {
        public ITypeDefinitionFilterSequence ResideInNamespace(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.ResideInNamespace(name));
            return this;
        }

        public ITypeDefinitionFilterSequence ResideInNamespaceContaining(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.ResideInNamespaceContaining(name));
            return this;
        }

        public ITypeDefinitionFilterSequence ResideInNamespaceEndingWith(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.ResideInNamespaceEndingWith(name));
            return this;
        }

        public ITypeDefinitionFilterSequence DoNotResideInNamespace(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.DoNotResideInNamespace(name));
            return this;
        }

        public ITypeDefinitionFilterSequence DoNotResideInNamespaceContaining(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.DoNotResideInNamespaceContaining(name));
            return this;
        }

        public ITypeDefinitionFilterSequence DoNotResideInNamespaceEndingWith(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.DoNotResideInNamespaceEndingWith(name));
            return this;
        }
    }
}
