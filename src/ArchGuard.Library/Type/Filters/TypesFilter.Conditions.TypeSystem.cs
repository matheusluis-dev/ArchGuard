namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions AreClasses()
        {
            _context.ApplyFilter(TypePredicate.Class);
            return this;
        }

        public ITypesFilterPostConditions AreNotClasses()
        {
            _context.ApplyFilter(TypePredicate.NotClass);
            return this;
        }

        public ITypesFilterPostConditions AreInterfaces()
        {
            _context.ApplyFilter(TypePredicate.Interface);
            return this;
        }

        public ITypesFilterPostConditions AreNotInterfaces()
        {
            _context.ApplyFilter(TypePredicate.NotInterface);
            return this;
        }

        public ITypesFilterPostConditions AreStructs()
        {
            _context.ApplyFilter(TypePredicate.Struct);
            return this;
        }

        public ITypesFilterPostConditions AreNotStructs()
        {
            _context.ApplyFilter(TypePredicate.NotStruct);
            return this;
        }

        public ITypesFilterPostConditions AreEnums()
        {
            _context.ApplyFilter(TypePredicate.Enum);
            return this;
        }

        public ITypesFilterPostConditions AreNotEnums()
        {
            _context.ApplyFilter(TypePredicate.NotEnum);
            return this;
        }

#if NET5_0_OR_GREATER
        public ITypesFilterPostConditions AreRecords()
        {
            _context.ApplyFilter(TypePredicate.Record);
            return this;
        }

        public ITypesFilterPostConditions AreNotRecords()
        {
            _context.ApplyFilter(TypePredicate.NotRecord);
            return this;
        }
#endif
    }
}
