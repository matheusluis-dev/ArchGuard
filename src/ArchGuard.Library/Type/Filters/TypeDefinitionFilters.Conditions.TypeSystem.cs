namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypeDefinitionFilters
    {
        public ITypesFilterPostConditions AreClasses()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Class);
            return this;
        }

        public ITypesFilterPostConditions AreNotClasses()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotClass);
            return this;
        }

        public ITypesFilterPostConditions AreInterfaces()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Interface);
            return this;
        }

        public ITypesFilterPostConditions AreNotInterfaces()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotInterface);
            return this;
        }

        public ITypesFilterPostConditions AreStructs()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Struct);
            return this;
        }

        public ITypesFilterPostConditions AreNotStructs()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotStruct);
            return this;
        }

        public ITypesFilterPostConditions AreEnums()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Enum);
            return this;
        }

        public ITypesFilterPostConditions AreNotEnums()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotEnum);
            return this;
        }

        public ITypesFilterPostConditions AreRecords()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Record);
            return this;
        }

        public ITypesFilterPostConditions AreNotRecords()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotRecord);
            return this;
        }
    }
}
