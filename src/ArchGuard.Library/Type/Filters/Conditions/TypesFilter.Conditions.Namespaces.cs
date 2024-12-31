namespace ArchGuard.Library.Type.Filters
{
    using System;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions ResideInNamespace(string name)
        {
            _context.ApplyFilter(f =>
                !(f.Namespace is null) && f.Namespace.Equals(name, StringComparison.Ordinal)
            );

            return this;
        }

        public ITypesFilterPostConditions ResideInNamespace(
            string name,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(f =>
                !(f.Namespace is null) && f.Namespace.Equals(name, comparison)
            );

            return this;
        }

        public ITypesFilterPostConditions ResideInNamespaceContaining(string name)
        {
            _context.ApplyFilter(f =>
                !(f.Namespace is null) && f.Namespace.IndexOf(name, StringComparison.Ordinal) >= 0
            );

            return this;
        }

        public ITypesFilterPostConditions ResideInNamespaceContaining(
            string name,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(f =>
                !(f.Namespace is null) && f.Namespace.IndexOf(name, comparison) >= 0
            );

            return this;
        }

        public ITypesFilterPostConditions ResideInNamespaceStartingWith(string name)
        {
            _context.ApplyFilter(f =>
                !(f.Namespace is null) && f.Namespace.StartsWith(name, StringComparison.Ordinal)
            );

            return this;
        }

        public ITypesFilterPostConditions ResideInNamespaceStartingWith(
            string name,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(f =>
                !(f.Namespace is null) && f.Namespace.StartsWith(name, comparison)
            );

            return this;
        }

        public ITypesFilterPostConditions ResideInNamespaceEndingWith(string name)
        {
            _context.ApplyFilter(f =>
                !(f.Namespace is null) && f.Namespace.EndsWith(name, StringComparison.Ordinal)
            );

            return this;
        }

        public ITypesFilterPostConditions ResideInNamespaceEndingWith(
            string name,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(f =>
                !(f.Namespace is null) && f.Namespace.EndsWith(name, comparison)
            );

            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespace(string name)
        {
            _context.ApplyFilter(f =>
                !(f.Namespace is null) && !f.Namespace.Equals(name, StringComparison.Ordinal)
            );

            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespace(
            string name,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(f =>
                !(f.Namespace is null) && !f.Namespace.Equals(name, comparison)
            );

            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceContaining(string name)
        {
            _context.ApplyFilter(f =>
                !(f.Namespace is null) && f.Namespace.IndexOf(name, StringComparison.Ordinal) < 0
            );

            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceContaining(
            string name,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(f =>
                !(f.Namespace is null) && f.Namespace.IndexOf(name, comparison) < 0
            );

            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceStartingWith(string name)
        {
            _context.ApplyFilter(f =>
                !(f.Namespace is null) && !f.Namespace.StartsWith(name, StringComparison.Ordinal)
            );

            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceStartingWith(
            string name,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(f =>
                !(f.Namespace is null) && !f.Namespace.StartsWith(name, comparison)
            );

            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceEndingWith(string name)
        {
            _context.ApplyFilter(f =>
                !(f.Namespace is null) && !f.Namespace.EndsWith(name, StringComparison.Ordinal)
            );

            return this;
        }

        public ITypesFilterPostConditions DoNotResideInNamespaceEndingWith(
            string name,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(f =>
                !(f.Namespace is null) && !f.Namespace.EndsWith(name, comparison)
            );

            return this;
        }
    }
}
