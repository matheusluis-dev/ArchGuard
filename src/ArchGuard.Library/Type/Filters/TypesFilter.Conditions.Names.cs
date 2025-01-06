namespace ArchGuard.Library.Type.Filters
{
    using System;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions HaveNameStartingWith(string name)
        {
            return HaveNameStartingWith(name, StringComparison.Ordinal);
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
            return HaveNameEndingWith(name, StringComparison.Ordinal);
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
