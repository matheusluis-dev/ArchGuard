namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions AreClasses()
        {
            _context.AddPredicate(TypeSpecPredicate.Class);
            return this;
        }

        public ITypesFilterPostConditions AreNotClasses()
        {
            _context.AddPredicate(TypeSpecPredicate.NotClass);
            return this;
        }

        public ITypesFilterPostConditions AreInterfaces()
        {
            _context.AddPredicate(TypeSpecPredicate.Interface);
            return this;
        }

        public ITypesFilterPostConditions AreNotInterfaces()
        {
            _context.AddPredicate(TypeSpecPredicate.NotInterface);
            return this;
        }

        public ITypesFilterPostConditions AreStructs()
        {
            _context.AddPredicate(TypeSpecPredicate.Struct);
            return this;
        }

        public ITypesFilterPostConditions AreNotStructs()
        {
            _context.AddPredicate(TypeSpecPredicate.NotStruct);
            return this;
        }

        public ITypesFilterPostConditions AreEnums()
        {
            _context.AddPredicate(TypeSpecPredicate.Enum);
            return this;
        }

        public ITypesFilterPostConditions AreNotEnums()
        {
            _context.AddPredicate(TypeSpecPredicate.NotEnum);
            return this;
        }

        public ITypesFilterPostConditions AreRecords()
        {
            _context.AddPredicate(TypeSpecPredicate.Record);
            return this;
        }

        public ITypesFilterPostConditions AreNotRecords()
        {
            _context.AddPredicate(TypeSpecPredicate.NotRecord);
            return this;
        }
    }
}
