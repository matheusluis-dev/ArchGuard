namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions HaveName(params string[] name)
        {
            _context.AddPredicate(TypeSpecPredicate.HaveName(name));
            return this;
        }

        public ITypesFilterPostConditions HaveNameMatching(params string[] regexes)
        {
            _context.AddPredicate(TypeSpecPredicate.HaveNameMatching(regexes));
            return this;
        }

        public ITypesFilterPostConditions HaveNameNotMatching(params string[] regexes)
        {
            _context.AddPredicate(TypeSpecPredicate.HaveNameNotMatching(regexes));
            return this;
        }

        public ITypesFilterPostConditions HaveFullName(params string[] name)
        {
            _context.AddPredicate(TypeSpecPredicate.HaveFullName(name));
            return this;
        }

        public ITypesFilterPostConditions HaveFullNameMatching(params string[] regexes)
        {
            _context.AddPredicate(TypeSpecPredicate.HaveFullNameMatching(regexes));
            return this;
        }

        public ITypesFilterPostConditions HaveFullNameNotMatching(params string[] regexes)
        {
            _context.AddPredicate(TypeSpecPredicate.HaveFullNameNotMatching(regexes));
            return this;
        }

        public ITypesFilterPostConditions HaveNameStartingWith(params string[] name)
        {
            _context.AddPredicate(TypeSpecPredicate.HaveNameStartingWith(name));
            return this;
        }

        public ITypesFilterPostConditions HaveNameEndingWith(params string[] name)
        {
            _context.AddPredicate(TypeSpecPredicate.HaveNameEndingWith(name));
            return this;
        }
    }
}
