namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Extensions.Type;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions AreClasses()
        {
            _context.ApplyFilter(type => type.IsNonRecordClass());
            return this;
        }

        public ITypesFilterPostConditions AreNotClasses()
        {
            _context.ApplyFilter(type => type.IsNotNonRecordClass());
            return this;
        }

        public ITypesFilterPostConditions AreInterfaces()
        {
            _context.ApplyFilter(type => type.IsInterface);
            return this;
        }

        public ITypesFilterPostConditions AreNotInterfaces()
        {
            _context.ApplyFilter(type => !type.IsInterface);
            return this;
        }

        public ITypesFilterPostConditions AreStructs()
        {
            _context.ApplyFilter(type => type.IsStruct());
            return this;
        }

        public ITypesFilterPostConditions AreNotStructs()
        {
            _context.ApplyFilter(type => type.IsNotStruct());
            return this;
        }

        public ITypesFilterPostConditions AreEnums()
        {
            _context.ApplyFilter(type => type.IsEnum);
            return this;
        }

        public ITypesFilterPostConditions AreNotEnums()
        {
            _context.ApplyFilter(type => !type.IsEnum);
            return this;
        }

#if NET5_0_OR_GREATER
        public ITypesFilterPostConditions AreRecords()
        {
            _context.ApplyFilter(type => type.IsRecord());
            return this;
        }

        public ITypesFilterPostConditions AreNotRecords()
        {
            _context.ApplyFilter(type => type.IsNotRecord());
            return this;
        }
#endif
    }
}
