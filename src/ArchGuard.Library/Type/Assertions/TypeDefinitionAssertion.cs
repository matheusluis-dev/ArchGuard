namespace ArchGuard.Library.Type.Assertions
{
    using ArchGuard.Library.Contexts;
    using ArchGuard.Library.Type.Assertions.Sequences;

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
