namespace ArchGuard.Library.Type.Assertions
{
    using ArchGuard.Library.Type.Assertions.Sequences;
    using ArchGuard.Library.Type.Contexts;

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
