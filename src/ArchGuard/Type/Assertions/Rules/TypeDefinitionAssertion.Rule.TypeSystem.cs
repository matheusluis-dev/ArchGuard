namespace ArchGuard
{
    using ArchGuardType.Predicates;

    public sealed partial class TypeDefinitionAssertion
    {
        public ITypeDefinitionAssertionSequence BeClasses()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Class);
            return this;
        }

        public ITypeDefinitionAssertionSequence NotBeClasses()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotClass);
            return this;
        }

        public ITypeDefinitionAssertionSequence BeInterfaces()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Interface);
            return this;
        }

        public ITypeDefinitionAssertionSequence NotBeInterfaces()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotInterface);
            return this;
        }

        public ITypeDefinitionAssertionSequence BeStructs()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Struct);
            return this;
        }

        public ITypeDefinitionAssertionSequence NotBeStructs()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotStruct);
            return this;
        }

        public ITypeDefinitionAssertionSequence BeEnums()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Enum);
            return this;
        }

        public ITypeDefinitionAssertionSequence NotBeEnums()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotEnum);
            return this;
        }

        public ITypeDefinitionAssertionSequence BeRecords()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Record);
            return this;
        }

        public ITypeDefinitionAssertionSequence NotBeRecords()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotRecord);
            return this;
        }

        public ITypeDefinitionAssertionSequence BeRecordStructs()
        {
            _context.AddPredicate(TypeDefinitionPredicate.RecordStruct);
            return this;
        }

        public ITypeDefinitionAssertionSequence NotBeRecordStructs()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotRecordStruct);
            return this;
        }
    }
}
