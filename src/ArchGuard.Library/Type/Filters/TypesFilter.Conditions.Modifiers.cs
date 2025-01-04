namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Extensions.Type;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions ArePartial()
        {
            _context.ApplyFilter(type => type.IsPartial());
            return this;
        }

        public ITypesFilterPostConditions AreNotPartial()
        {
            _context.ApplyFilter(type => type.IsNotPartial());
            return this;
        }

        public ITypesFilterPostConditions AreSealed()
        {
            _context.ApplyFilter(type => type.IsSealed());
            return this;
        }

        public ITypesFilterPostConditions AreNotSealed()
        {
            _context.ApplyFilter(type => type.IsNotSealed());
            return this;
        }

        public ITypesFilterPostConditions AreNested()
        {
            _context.ApplyFilter(type => type.IsNested);
            return this;
        }

        public ITypesFilterPostConditions AreNotNested()
        {
            _context.ApplyFilter(type => !type.IsNested);
            return this;
        }

        public ITypesFilterPostConditions AreStatic()
        {
            _context.ApplyFilter(type => type.IsStatic());
            return this;
        }

        public ITypesFilterPostConditions AreNotStatic()
        {
            _context.ApplyFilter(type => type.IsNotStatic());
            return this;
        }
    }
}
