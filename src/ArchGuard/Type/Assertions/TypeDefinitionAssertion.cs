namespace ArchGuardType.Assertions
{
    using ArchGuard.Contexts;
    using ArchGuardType.Assertions.Sequences;

    public sealed partial class TypeDefinitionAssertion
        : ITypeDefinitionAssertionRule,
            ITypeDefinitionAssertionSequence
    {
        private readonly TypeDefinitionAssertionContext _context;

        internal TypeDefinitionAssertion(TypeDefinitionAssertionContext context)
        {
            _context = context;
        }

        internal ITypeDefinitionAssertionRule Start()
        {
            return this;
        }
    }
}
