namespace ArchGuard.Library.Type.Filters
{
    using System;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions HaveNameStartingWith(string name)
        {
            _context.ApplyFilter(type => type.Name.StartsWith(name));
            return this;
        }

        public ITypesFilterPostConditions HaveNameStartingWith(
            string name,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(type => type.Name.StartsWith(name, comparison));
            return this;
        }

        public ITypesFilterPostConditions HaveNameEndingWith(string name)
        {
            _context.ApplyFilter(type => type.Name.EndsWith(name));
            return this;
        }

        public ITypesFilterPostConditions HaveNameEndingWith(
            string name,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(type => type.Name.EndsWith(name, comparison));
            return this;
        }
    }
}
