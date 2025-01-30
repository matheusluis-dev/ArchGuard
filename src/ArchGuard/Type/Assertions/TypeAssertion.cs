namespace ArchGuard
{
    using ArchGuard.Contexts;

    public sealed partial class TypeAssertion : ITypeAssertionRule, ITypeAssertionSequence
    {
        private readonly TypeAssertionContext _context;

        public TypeAssertion(TypeAssertionContext context)
        {
            _context = context;
        }

        public ITypeAssertionRule Start()
        {
            return this;
        }
    }
}
