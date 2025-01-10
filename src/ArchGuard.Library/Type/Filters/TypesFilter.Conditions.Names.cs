namespace ArchGuard.Library.Type.Filters
{
    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions HaveName(params string[] name)
        {
            _context.AddPredicate(TypePredicate.HaveName(name));
            return this;
        }

        public ITypesFilterPostConditions HaveNameMatching(params string[] regexes)
        {
            _context.AddPredicate(TypePredicate.HaveNameMatching(regexes));
            return this;
        }

        public ITypesFilterPostConditions HaveNameNotMatching(params string[] regexes)
        {
            _context.AddPredicate(TypePredicate.HaveNameNotMatching(regexes));
            return this;
        }

        public ITypesFilterPostConditions HaveFullName(params string[] name)
        {
            _context.AddPredicate(TypePredicate.HaveFullName(name));
            return this;
        }

        public ITypesFilterPostConditions HaveFullNameMatching(params string[] regexes)
        {
            _context.AddPredicate(TypePredicate.HaveFullNameMatching(regexes));
            return this;
        }

        public ITypesFilterPostConditions HaveFullNameNotMatching(params string[] regexes)
        {
            _context.AddPredicate(TypePredicate.HaveFullNameNotMatching(regexes));
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
