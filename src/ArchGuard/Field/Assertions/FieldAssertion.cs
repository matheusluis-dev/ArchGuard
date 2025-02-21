namespace ArchGuard
{
    using ArchGuard.Core.Contexts;
    using ArchGuard.Core.Field.Models;

    public sealed partial class FieldAssertion : IFieldAssertionRule, IFieldAssertionSequence
    {
        private readonly AssertionContext<FieldDefinition> _context;

        public FieldAssertion(AssertionContext<FieldDefinition> context)
        {
            _context = context;
        }

        public IFieldAssertionRule Start()
        {
            return this;
        }

        public AssertionResult<FieldDefinition> GetResult()
        {
            return GetResult(Default.StringComparison);
        }

        public AssertionResult<FieldDefinition> GetResult(StringComparison comparison)
        {
            return _context.GetResult(comparison);
        }
    }
}
