namespace ArchGuard
{
    using ArchGuard.Contexts;

    public sealed partial class MethodAssertion : IMethodAssertionRule, IMethodAssertionSequence
    {
        private readonly MethodAssertionContext _context;

        public MethodAssertion(MethodAssertionContext context)
        {
            _context = context;
        }

        public IMethodAssertionRule Start()
        {
            return this;
        }
    }
}
