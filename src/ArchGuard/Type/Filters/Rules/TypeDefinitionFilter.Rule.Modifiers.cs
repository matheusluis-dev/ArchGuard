namespace ArchGuardType.Filters
{
    using ArchGuardType.Predicates;

    public sealed partial class TypeDefinitionFilter
    {
        public ITypeDefinitionFilterSequence ArePartial()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Partial);
            return this;
        }

        public ITypeDefinitionFilterSequence AreNotPartial()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotPartial);
            return this;
        }

        public ITypeDefinitionFilterSequence AreSealed()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Sealed);
            return this;
        }

        public ITypeDefinitionFilterSequence AreNotSealed()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotSealed);
            return this;
        }

        public ITypeDefinitionFilterSequence AreNested()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Nested);
            return this;
        }

        public ITypeDefinitionFilterSequence AreNotNested()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotNested);
            return this;
        }

        public ITypeDefinitionFilterSequence AreStatic()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Static);
            return this;
        }

        public ITypeDefinitionFilterSequence AreNotStatic()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotStatic);
            return this;
        }
    }
}
