namespace ArchGuard.Library.Type.Filters
{
    using System;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions HaveName(string name)
        {
            return HaveName(name, StringComparison.CurrentCulture);
        }

        public ITypesFilterPostConditions HaveName(string name, StringComparison comparison)
        {
            _context.ApplyFilter(TypePredicate.HaveName(name, comparison));
            return this;
        }

        public ITypesFilterPostConditions HaveFullName(string name)
        {
            return HaveFullName(name, StringComparison.CurrentCulture);
        }

        public ITypesFilterPostConditions HaveFullName(string name, StringComparison comparison)
        {
            _context.ApplyFilter(TypePredicate.HaveFullName(name, comparison));
            return this;
        }

        public ITypesFilterPostConditions HaveNameStartingWith(string name)
        {
            return HaveNameStartingWith(name, StringComparison.CurrentCulture);
        }

        public ITypesFilterPostConditions HaveNameStartingWith(
            string name,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(TypePredicate.HaveNameStartingWith(name, comparison));
            return this;
        }

        public ITypesFilterPostConditions HaveNameEndingWith(string name)
        {
            return HaveNameEndingWith(name, StringComparison.CurrentCulture);
        }

        public ITypesFilterPostConditions HaveNameEndingWith(
            string name,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(TypePredicate.HaveNameEndingWith(name, comparison));
            return this;
        }
    }
}
