namespace ArchGuard
{
    using ArchGuard.Core.Field.Contexts;
    using ArchGuard.Core.Field.Models;

    public sealed partial class FieldAssertion : IFieldAssertionRule, IFieldAssertionSequence
    {
        private readonly FieldAssertionContext _context;

        public FieldAssertion(FieldAssertionContext context)
        {
            _context = context;
        }

        public IFieldAssertionRule Start()
        {
            return this;
        }

        public FieldAssertionResult GetResult()
        {
            return GetResult(Default.StringComparison);
        }

        public FieldAssertionResult GetResult(StringComparison comparison)
        {
            return _context.GetResult(comparison);
        }
    }
}
