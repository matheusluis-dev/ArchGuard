namespace ArchGuard.Library.Type.Filters
{
    using System;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions ResideInNamespace(string name)
        {
            return ResideInNamespace(name, StringComparison.CurrentCulture);
        }

        public ITypesFilterPostConditions ResideInNamespace(
            string name,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(TypePredicate.ResideInNamespace(name, comparison));
            return this;
        }

        public ITypesFilterPostConditions ResideInNamespaceContaining(string name)
        {
            return ResideInNamespaceContaining(name, StringComparison.CurrentCulture);
        }

        public ITypesFilterPostConditions ResideInNamespaceContaining(
            string name,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(TypePredicate.ResideInNamespaceContaining(name, comparison));
            return this;
        }

        public ITypesFilterPostConditions ResideInNamespaceEndingWith(string name)
        {
            return ResideInNamespaceEndingWith(name, StringComparison.CurrentCulture);
        }

        public ITypesFilterPostConditions ResideInNamespaceEndingWith(
            string name,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(TypePredicate.ResideInNamespaceEndingWith(name, comparison));
            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespace(string name)
        {
            return DoNotResideInNamespace(name, StringComparison.CurrentCulture);
        }

        public ITypesFilterPostConditions DoNotResideInNamespace(
            string name,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(TypePredicate.DoNotResideInNamespace(name, comparison));
            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceContaining(string name)
        {
            return DoNotResideInNamespaceContaining(name, StringComparison.CurrentCulture);
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceContaining(
            string name,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(TypePredicate.DoNotResideInNamespaceContaining(name, comparison));
            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceEndingWith(string name)
        {
            return DoNotResideInNamespaceEndingWith(name, StringComparison.CurrentCulture);
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceEndingWith(
            string name,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(TypePredicate.DoNotResideInNamespaceEndingWith(name, comparison));
            return this;
        }
    }
}
