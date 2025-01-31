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

        public MethodAssertionResult GetResult()
        {
            return GetResult(Default.StringComparison);
        }

        public MethodAssertionResult GetResult(StringComparison comparison)
        {
            return _context.GetResult(comparison);
        }
    }
}
