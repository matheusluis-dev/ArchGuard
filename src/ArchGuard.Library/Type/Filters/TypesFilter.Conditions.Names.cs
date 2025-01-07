namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions HaveName(params string[] name)
        {
            _context.AddPredicate(TypePredicate.HaveName(name));
            return this;
        }

        public ITypesFilterPostConditions HaveNameMatching(string regex)
        {
            _context.AddPredicate(TypePredicate.HaveNameMatching(regex));
            return this;
        }

        public ITypesFilterPostConditions HaveNameNotMatching(string regex)
        {
            _context.AddPredicate(TypePredicate.HaveNameNotMatching(regex));
            return this;
        }

        public ITypesFilterPostConditions HaveFullName(params string[] name)
        {
            _context.AddPredicate(TypePredicate.HaveFullName(name));
            return this;
        }

        public ITypesFilterPostConditions HaveFullNameMatching(string regex)
        {
            _context.AddPredicate(TypePredicate.HaveFullNameMatching(regex));
            return this;
        }

        public ITypesFilterPostConditions HaveFullNameNotMatching(string regex)
        {
            _context.AddPredicate(TypePredicate.HaveFullNameNotMatching(regex));
            return this;
        }

        public ITypesFilterPostConditions HaveNameStartingWith(params string[] name)
        {
            _context.AddPredicate(TypePredicate.HaveNameStartingWith(name));
            return this;
        }

        public ITypesFilterPostConditions HaveNameEndingWith(params string[] name)
        {
            _context.AddPredicate(TypePredicate.HaveNameEndingWith(name));
            return this;
        }
    }
}
