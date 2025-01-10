namespace ArchGuard.Library.Type.Filters
{
    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions AreClasses()
        {
            _context.AddPredicate(TypePredicate.Class);
            return this;
        }

        public ITypesFilterPostConditions AreNotClasses()
        {
            _context.AddPredicate(TypePredicate.NotClass);
            return this;
        }

        public ITypesFilterPostConditions AreInterfaces()
        {
            _context.AddPredicate(TypePredicate.Interface);
            return this;
        }

        public ITypesFilterPostConditions AreNotInterfaces()
        {
            _context.AddPredicate(TypePredicate.NotInterface);
            return this;
        }

        public ITypesFilterPostConditions AreStructs()
        {
            _context.AddPredicate(TypePredicate.Struct);
            return this;
        }

        public ITypesFilterPostConditions AreNotStructs()
        {
            _context.AddPredicate(TypePredicate.NotStruct);
            return this;
        }

        public ITypesFilterPostConditions AreEnums()
        {
            _context.AddPredicate(TypePredicate.Enum);
            return this;
        }

        public ITypesFilterPostConditions AreNotEnums()
        {
            _context.AddPredicate(TypePredicate.NotEnum);
            return this;
        }

        public ITypesFilterPostConditions AreRecords()
        {
            _context.AddPredicate(TypePredicate.Record);
            return this;
        }

        public ITypesFilterPostConditions AreNotRecords()
        {
            _context.AddPredicate(TypePredicate.NotRecord);
            return this;
        }
    }
}
