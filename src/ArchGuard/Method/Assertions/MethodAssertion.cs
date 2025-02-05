namespace ArchGuard
{
    using ArchGuard.Core.Method.Contexts;
    using ArchGuard.Core.Method.Models;

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
