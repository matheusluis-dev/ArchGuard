namespace ArchGuard
{
    using ArchGuardType.Predicates;

    public sealed partial class TypeDefinitionFilter
    {
        public ITypeDefinitionFilterSequence AreClasses()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Class);
            return this;
        }

        public ITypeDefinitionFilterSequence AreNotClasses()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotClass);
            return this;
        }

        public ITypeDefinitionFilterSequence AreInterfaces()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Interface);
            return this;
        }

        public ITypeDefinitionFilterSequence AreNotInterfaces()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotInterface);
            return this;
        }

        public ITypeDefinitionFilterSequence AreStructs()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Struct);
            return this;
        }

        public ITypeDefinitionFilterSequence AreNotStructs()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotStruct);
            return this;
        }

        public ITypeDefinitionFilterSequence AreEnums()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Enum);
            return this;
        }

        public ITypeDefinitionFilterSequence AreNotEnums()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotEnum);
            return this;
        }

        public ITypeDefinitionFilterSequence AreRecords()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Record);
            return this;
        }

        public ITypeDefinitionFilterSequence AreNotRecords()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotRecord);
            return this;
        }

        public ITypeDefinitionFilterSequence AreRecordStructs()
        {
            _context.AddPredicate(TypeDefinitionPredicate.RecordStruct);
            return this;
        }

        public ITypeDefinitionFilterSequence AreNotRecordStructs()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotRecordStruct);
            return this;
        }
    }
}
