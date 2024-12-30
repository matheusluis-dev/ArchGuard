namespace ArchGuard.Library.Types.Filters
{
    using ArchGuard.Library.Extensions;
    using ArchGuard.Library.Types.Filters.PostConditions.Interfaces;

    public sealed partial class TypesFilter
    {
        // TODO move to a proper location
        public ITypesFilterPostConditions AreNested()
        {
            _context.ApplyFilter(type => type.IsNested);
            return this;
        }

        // TODO move to a proper location
        public ITypesFilterPostConditions AreNotNested()
        {
            _context.ApplyFilter(type => !type.IsNested);
            return this;
        }

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
    }
}
