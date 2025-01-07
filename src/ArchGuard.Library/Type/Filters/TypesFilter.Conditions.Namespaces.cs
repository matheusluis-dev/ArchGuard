namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions ResideInNamespace(string name)
        {
            _context.AddPredicate(TypePredicate.ResideInNamespace(name));
            return this;
        }

        public ITypesFilterPostConditions ResideInNamespaceContaining(string name)
        {
            _context.AddPredicate(TypePredicate.ResideInNamespaceContaining(name));
            return this;
        }

        public ITypesFilterPostConditions ResideInNamespaceEndingWith(string name)
        {
            _context.AddPredicate(TypePredicate.ResideInNamespaceEndingWith(name));
            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespace(string name)
        {
            _context.AddPredicate(TypePredicate.DoNotResideInNamespace(name));
            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceContaining(string name)
        {
            _context.AddPredicate(TypePredicate.DoNotResideInNamespaceContaining(name));
            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceEndingWith(string name)
        {
            _context.AddPredicate(TypePredicate.DoNotResideInNamespaceEndingWith(name));
            return this;
        }
    }
}
