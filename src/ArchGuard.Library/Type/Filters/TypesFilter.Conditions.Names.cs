namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions HaveName(string name)
        {
            _context.AddPredicate(TypePredicate.HaveName(name));
            return this;
        }

        public ITypesFilterPostConditions HaveFullName(string name)
        {
            _context.AddPredicate(TypePredicate.HaveFullName(name));
            return this;
        }

        public ITypesFilterPostConditions HaveNameStartingWith(string name)
        {
            _context.AddPredicate(TypePredicate.HaveNameStartingWith(name));
            return this;
        }

        public ITypesFilterPostConditions HaveNameEndingWith(string name)
        {
            _context.AddPredicate(TypePredicate.HaveNameEndingWith(name));
            return this;
        }
    }
}
