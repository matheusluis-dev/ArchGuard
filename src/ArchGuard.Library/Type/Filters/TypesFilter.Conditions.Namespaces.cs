namespace ArchGuard.Library.Type.Filters
{
    using System;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions ResideInNamespace(string name)
        {
            return ResideInNamespace(name, _comparison);
        }

        public ITypesFilterPostConditions ResideInNamespace(
            string name,
            StringComparison comparison
        )
        {
            _context.AddPredicate(TypePredicate.ResideInNamespace(name, comparison));
            return this;
        }

        public ITypesFilterPostConditions ResideInNamespaceContaining(string name)
        {
            return ResideInNamespaceContaining(name, _comparison);
        }

        public ITypesFilterPostConditions ResideInNamespaceContaining(
            string name,
            StringComparison comparison
        )
        {
            _context.AddPredicate(TypePredicate.ResideInNamespaceContaining(name, comparison));
            return this;
        }

        public ITypesFilterPostConditions ResideInNamespaceEndingWith(string name)
        {
            return ResideInNamespaceEndingWith(name, _comparison);
        }

        public ITypesFilterPostConditions ResideInNamespaceEndingWith(
            string name,
            StringComparison comparison
        )
        {
            _context.AddPredicate(TypePredicate.ResideInNamespaceEndingWith(name, comparison));
            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespace(string name)
        {
            return DoNotResideInNamespace(name, _comparison);
        }

        public ITypesFilterPostConditions DoNotResideInNamespace(
            string name,
            StringComparison comparison
        )
        {
            _context.AddPredicate(TypePredicate.DoNotResideInNamespace(name, comparison));
            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceContaining(string name)
        {
            return DoNotResideInNamespaceContaining(name, _comparison);
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceContaining(
            string name,
            StringComparison comparison
        )
        {
            _context.AddPredicate(TypePredicate.DoNotResideInNamespaceContaining(name, comparison));
            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceEndingWith(string name)
        {
            return DoNotResideInNamespaceEndingWith(name, _comparison);
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceEndingWith(
            string name,
            StringComparison comparison
        )
        {
            _context.AddPredicate(TypePredicate.DoNotResideInNamespaceEndingWith(name, comparison));
            return this;
        }
    }
}
