namespace ArchGuard
{
    using ArchGuardType.Predicates;

    public sealed partial class TypeAssertion
    {
        public ITypeAssertionSequence BeClasses()
        {
            _context.AddPredicate(TypePredicate.Class);
            return this;
        }

        public ITypeAssertionSequence NotBeClasses()
        {
            _context.AddPredicate(TypePredicate.NotClass);
            return this;
        }

        public ITypeAssertionSequence BeInterfaces()
        {
            _context.AddPredicate(TypePredicate.Interface);
            return this;
        }

        public ITypeAssertionSequence NotBeInterfaces()
        {
            _context.AddPredicate(TypePredicate.NotInterface);
            return this;
        }

        public ITypeAssertionSequence BeStructs()
        {
            _context.AddPredicate(TypePredicate.Struct);
            return this;
        }

        public ITypeAssertionSequence NotBeStructs()
        {
            _context.AddPredicate(TypePredicate.NotStruct);
            return this;
        }

        public ITypeAssertionSequence BeEnums()
        {
            _context.AddPredicate(TypePredicate.Enum);
            return this;
        }

        public ITypeAssertionSequence NotBeEnums()
        {
            _context.AddPredicate(TypePredicate.NotEnum);
            return this;
        }

        public ITypeAssertionSequence BeRecords()
        {
            _context.AddPredicate(TypePredicate.Record);
            return this;
        }

        public ITypeAssertionSequence NotBeRecords()
        {
            _context.AddPredicate(TypePredicate.NotRecord);
            return this;
        }

        public ITypeAssertionSequence BeRecordStructs()
        {
            _context.AddPredicate(TypePredicate.RecordStruct);
            return this;
        }

        public ITypeAssertionSequence NotBeRecordStructs()
        {
            _context.AddPredicate(TypePredicate.NotRecordStruct);
            return this;
        }
    }
}
