namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions ResideInNamespace(params string[] name)
        {
            _context.AddPredicate(TypeSpecPredicate.ResideInNamespace(name));
            return this;
        }

        public ITypesFilterPostConditions ResideInNamespaceContaining(params string[] name)
        {
            _context.AddPredicate(TypeSpecPredicate.ResideInNamespaceContaining(name));
            return this;
        }

        public ITypesFilterPostConditions ResideInNamespaceEndingWith(params string[] name)
        {
            _context.AddPredicate(TypeSpecPredicate.ResideInNamespaceEndingWith(name));
            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespace(params string[] name)
        {
            _context.AddPredicate(TypeSpecPredicate.DoNotResideInNamespace(name));
            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceContaining(params string[] name)
        {
            _context.AddPredicate(TypeSpecPredicate.DoNotResideInNamespaceContaining(name));
            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceEndingWith(params string[] name)
        {
            _context.AddPredicate(TypeSpecPredicate.DoNotResideInNamespaceEndingWith(name));
            return this;
        }
    }
}
