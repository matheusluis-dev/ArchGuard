namespace ArchGuard
{
    using ArchGuard.Contexts;

    public sealed partial class TypeDefinitionAssertion
        : ITypeDefinitionAssertionRule,
            ITypeDefinitionAssertionSequence
    {
        private readonly TypeDefinitionAssertionContext _context;

        public TypeDefinitionAssertion(TypeDefinitionAssertionContext context)
        {
            _context = context;
        }

        public ITypeDefinitionAssertionRule Start()
        {
            return this;
        }
    }
}
