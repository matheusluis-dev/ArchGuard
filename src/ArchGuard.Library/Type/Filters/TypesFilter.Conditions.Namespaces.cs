namespace ArchGuard.Library.Type.Filters
{
    using System;
    using System.Linq;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public sealed partial class TypesFilter
    {
        private void DefaultNamespaceFilterPrefix(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            _context.ApplyFilter(f => !(f.Namespace is null));
        }

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
            DefaultNamespaceFilterPrefix(name);

            var namespaceExists = _context.Types.Any(type =>
                type.Namespace.Equals(name, StringComparison.Ordinal)
            );
            var @namespace = namespaceExists || name[name.Length - 1] == '.' ? name : name + ".";

            _context.ApplyFilter(f => f.Namespace.StartsWith(@namespace, comparison));

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
            DefaultNamespaceFilterPrefix(name);

            _context.ApplyFilter(f => f.Namespace.IndexOf(name, comparison) >= 0);

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
            DefaultNamespaceFilterPrefix(name);

            _context.ApplyFilter(f => f.Namespace.EndsWith(name, comparison));

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
            DefaultNamespaceFilterPrefix(name);

            _context.ApplyFilter(f => !f.Namespace.Equals(name, comparison));

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
            DefaultNamespaceFilterPrefix(name);

            _context.ApplyFilter(f => f.Namespace.IndexOf(name, comparison) < 0);

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
            DefaultNamespaceFilterPrefix(name);

            _context.ApplyFilter(f => !f.Namespace.EndsWith(name, comparison));

            return this;
        }
    }
}
