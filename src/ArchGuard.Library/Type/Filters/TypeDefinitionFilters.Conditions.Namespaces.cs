namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypeDefinitionFilters
    {
        public ITypesFilterPostConditions ResideInNamespace(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.ResideInNamespace(name));
            return this;
        }

        public ITypesFilterPostConditions ResideInNamespaceContaining(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.ResideInNamespaceContaining(name));
            return this;
        }

        public ITypesFilterPostConditions ResideInNamespaceEndingWith(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.ResideInNamespaceEndingWith(name));
            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespace(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.DoNotResideInNamespace(name));
            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceContaining(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.DoNotResideInNamespaceContaining(name));
            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceEndingWith(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.DoNotResideInNamespaceEndingWith(name));
            return this;
        }
    }
}
