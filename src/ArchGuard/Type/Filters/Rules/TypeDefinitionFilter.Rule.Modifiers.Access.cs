namespace ArchGuardType.Filters
{
    using ArchGuardType.Predicates;

    public sealed partial class TypeDefinitionFilter
    {
        public ITypeDefinitionFilterSequence ArePublic()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Public);
            return this;
        }

        public ITypeDefinitionFilterSequence AreNotPublic()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotPublic);
            return this;
        }

        public ITypeDefinitionFilterSequence AreInternal()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Internal);
            return this;
        }

        public ITypeDefinitionFilterSequence AreNotInternal()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotInternal);
            return this;
        }

        public ITypeDefinitionFilterSequence ArePrivate()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Private);
            return this;
        }

        public ITypeDefinitionFilterSequence AreNotPrivate()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotPrivate);
            return this;
        }

        public ITypeDefinitionFilterSequence AreProtected()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Protected);
            return this;
        }

        public ITypeDefinitionFilterSequence AreNotProtected()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotProtected);
            return this;
        }

        public ITypeDefinitionFilterSequence AreFileScoped()
        {
            _context.AddPredicate(TypeDefinitionPredicate.FileScoped);
            return this;
        }

        public ITypeDefinitionFilterSequence AreNotFileScoped()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotFileScoped);
            return this;
        }
    }
}
