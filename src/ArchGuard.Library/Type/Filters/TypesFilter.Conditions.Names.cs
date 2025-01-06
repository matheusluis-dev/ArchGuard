namespace ArchGuard.Library.Type.Filters
{
    using System;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions HaveName(string name)
        {
            return HaveName(name, _comparison);
        }

        public ITypesFilterPostConditions HaveName(string name, StringComparison comparison)
        {
            _context.AddPredicate(TypePredicate.HaveName(name, comparison));
            return this;
        }

        public ITypesFilterPostConditions HaveFullName(string name)
        {
            return HaveFullName(name, _comparison);
        }

        public ITypesFilterPostConditions HaveFullName(string name, StringComparison comparison)
        {
            _context.AddPredicate(TypePredicate.HaveFullName(name, comparison));
            return this;
        }

        public ITypesFilterPostConditions HaveNameStartingWith(string name)
        {
            return HaveNameStartingWith(name, _comparison);
        }

        public ITypesFilterPostConditions HaveNameStartingWith(
            string name,
            StringComparison comparison
        )
        {
            _context.AddPredicate(TypePredicate.HaveNameStartingWith(name, comparison));
            return this;
        }

        public ITypesFilterPostConditions HaveNameEndingWith(string name)
        {
            return HaveNameEndingWith(name, _comparison);
        }

        public ITypesFilterPostConditions HaveNameEndingWith(
            string name,
            StringComparison comparison
        )
        {
            _context.AddPredicate(TypePredicate.HaveNameEndingWith(name, comparison));
            return this;
        }
    }
}
