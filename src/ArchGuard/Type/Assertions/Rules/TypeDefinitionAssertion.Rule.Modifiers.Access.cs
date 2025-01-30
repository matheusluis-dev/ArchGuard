namespace ArchGuard
{
    using ArchGuardType.Predicates;

    public sealed partial class TypeDefinitionAssertion
    {
        public ITypeDefinitionAssertionSequence BePublic()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Public);
            return this;
        }

        public ITypeDefinitionAssertionSequence NotBePublic()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotPublic);
            return this;
        }

        public ITypeDefinitionAssertionSequence BeInternal()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Internal);
            return this;
        }

        public ITypeDefinitionAssertionSequence NotBeInternal()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotInternal);
            return this;
        }

        public ITypeDefinitionAssertionSequence BePrivate()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Private);
            return this;
        }

        public ITypeDefinitionAssertionSequence NotBePrivate()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotPrivate);
            return this;
        }

        public ITypeDefinitionAssertionSequence BeProtected()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Protected);
            return this;
        }

        public ITypeDefinitionAssertionSequence NotBeProtected()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotProtected);
            return this;
        }

        public ITypeDefinitionAssertionSequence BeFileScoped()
        {
            _context.AddPredicate(TypeDefinitionPredicate.FileScoped);
            return this;
        }

        public ITypeDefinitionAssertionSequence NotBeFileScoped()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotFileScoped);
            return this;
        }
    }
}
