namespace ArchGuard
{
    using ArchGuardType.Predicates;

    public sealed partial class TypeFilter
    {
        public ITypeFilterSequence AreClasses()
        {
            _context.AddPredicate(TypePredicate.Class);
            return this;
        }

        public ITypeFilterSequence AreNotClasses()
        {
            _context.AddPredicate(TypePredicate.NotClass);
            return this;
        }

        public ITypeFilterSequence AreInterfaces()
        {
            _context.AddPredicate(TypePredicate.Interface);
            return this;
        }

        public ITypeFilterSequence AreNotInterfaces()
        {
            _context.AddPredicate(TypePredicate.NotInterface);
            return this;
        }

        public ITypeFilterSequence AreStructs()
        {
            _context.AddPredicate(TypePredicate.Struct);
            return this;
        }

        public ITypeFilterSequence AreNotStructs()
        {
            _context.AddPredicate(TypePredicate.NotStruct);
            return this;
        }

        public ITypeFilterSequence AreEnums()
        {
            _context.AddPredicate(TypePredicate.Enum);
            return this;
        }

        public ITypeFilterSequence AreNotEnums()
        {
            _context.AddPredicate(TypePredicate.NotEnum);
            return this;
        }

        public ITypeFilterSequence AreRecords()
        {
            _context.AddPredicate(TypePredicate.Record);
            return this;
        }

        public ITypeFilterSequence AreNotRecords()
        {
            _context.AddPredicate(TypePredicate.NotRecord);
            return this;
        }

        public ITypeFilterSequence AreRecordStructs()
        {
            _context.AddPredicate(TypePredicate.RecordStruct);
            return this;
        }

        public ITypeFilterSequence AreNotRecordStructs()
        {
            _context.AddPredicate(TypePredicate.NotRecordStruct);
            return this;
        }
    }
}
