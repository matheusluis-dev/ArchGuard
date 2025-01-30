namespace ArchGuard
{
    using ArchGuard.Contexts;

    public sealed partial class TypeAssertion : ITypeAssertionRule, ITypeAssertionSequence
    {
        private readonly TypeDefinitionAssertionContext _context;

        public TypeAssertion(TypeDefinitionAssertionContext context)
        {
            _context = context;
        }

        public ITypeAssertionRule Start()
        {
            return this;
        }
    }
}
