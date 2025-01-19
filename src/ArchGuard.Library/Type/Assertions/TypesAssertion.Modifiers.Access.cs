namespace ArchGuard.Library.Type.Assertions
{
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesAssertion
    {
        public ITypesAssertionPostCondition BePublic()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Public);
            return this;
        }

        public ITypesAssertionPostCondition NotBePublic()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotPublic);
            return this;
        }

        public ITypesAssertionPostCondition BeInternal()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Internal);
            return this;
        }

        public ITypesAssertionPostCondition NotBeInternal()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotInternal);
            return this;
        }

        public ITypesAssertionPostCondition BePrivate()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Private);
            return this;
        }

        public ITypesAssertionPostCondition NotBePrivate()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotPrivate);
            return this;
        }

        public ITypesAssertionPostCondition BeProtected()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Protected);
            return this;
        }

        public ITypesAssertionPostCondition NotBeProtected()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotProtected);
            return this;
        }

        public ITypesAssertionPostCondition BeFileScoped()
        {
            _context.AddPredicate(TypeDefinitionPredicate.FileScoped);
            return this;
        }

        public ITypesAssertionPostCondition NotBeFileScoped()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotFileScoped);
            return this;
        }
    }
}
