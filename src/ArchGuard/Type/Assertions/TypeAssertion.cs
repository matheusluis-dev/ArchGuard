namespace ArchGuard
{
    using ArchGuard.Core.Contexts;
    using ArchGuard.Core.Type.Models;

    public sealed partial class TypeAssertion : ITypeAssertionRule, ITypeAssertionSequence
    {
        private readonly AssertionContext<TypeDefinition> _context;

        public TypeAssertion(AssertionContext<TypeDefinition> context)
        {
            _context = context;
        }

        public ITypeAssertionRule Start()
        {
            return this;
        }
    }
}
