namespace ArchGuard
{
    using ArchGuard.Core.Contexts;
    using ArchGuard.Core.Method.Models;

    public sealed partial class MethodAssertion : IMethodAssertionRule, IMethodAssertionSequence
    {
        private readonly AssertionContext<MethodDefinition> _context;

        public MethodAssertion(AssertionContext<MethodDefinition> context)
        {
            _context = context;
        }

        public IMethodAssertionRule Start()
        {
            return this;
        }

        public AssertionResult<MethodDefinition> GetResult()
        {
            return GetResult(Default.StringComparison);
        }

        public AssertionResult<MethodDefinition> GetResult(StringComparison comparison)
        {
            return _context.GetResult(comparison);
        }
    }
}
