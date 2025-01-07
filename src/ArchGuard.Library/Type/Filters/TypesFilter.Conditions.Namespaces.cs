namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions ResideInNamespace(params string[] name)
        {
            _context.AddPredicate(TypePredicate.ResideInNamespace(name));
            return this;
        }

        public ITypesFilterPostConditions ResideInNamespaceContaining(params string[] name)
        {
            _context.AddPredicate(TypePredicate.ResideInNamespaceContaining(name));
            return this;
        }

        public ITypesFilterPostConditions ResideInNamespaceEndingWith(params string[] name)
        {
            _context.AddPredicate(TypePredicate.ResideInNamespaceEndingWith(name));
            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespace(params string[] name)
        {
            _context.AddPredicate(TypePredicate.DoNotResideInNamespace(name));
            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceContaining(params string[] name)
        {
            _context.AddPredicate(TypePredicate.DoNotResideInNamespaceContaining(name));
            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceEndingWith(params string[] name)
        {
            _context.AddPredicate(TypePredicate.DoNotResideInNamespaceEndingWith(name));
            return this;
        }
    }
}
