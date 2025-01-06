namespace ArchGuard.Library.Type.Filters
{
    using System;
    using System.Linq;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions ResideInNamespace(string name)
        {
            ResideInNamespace(name, StringComparison.CurrentCulture);
            return this;
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
            ResideInNamespaceContaining(name, StringComparison.CurrentCulture);
            return this;
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
            ResideInNamespaceEndingWith(name, StringComparison.CurrentCulture);
            return this;
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
            DoNotResideInNamespace(name, StringComparison.CurrentCulture);
            return this;
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
            DoNotResideInNamespaceContaining(name, StringComparison.CurrentCulture);
            return this;
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
            DoNotResideInNamespaceEndingWith(name, StringComparison.CurrentCulture);
            return this;
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
