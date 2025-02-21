namespace ArchGuard
{
    using ArchGuard.Core.Contexts;
    using ArchGuard.Core.Property.Models;

    public sealed partial class PropertyAssertion : IPropertyAssertionRule, IPropertyAssertionSequence
    {
        private readonly AssertionContext<PropertyDefinition> _context;

        public PropertyAssertion(AssertionContext<PropertyDefinition> context)
        {
            _context = context;
        }

        public IPropertyAssertionRule Start()
        {
            return this;
        }

        public AssertionResult<PropertyDefinition> GetResult()
        {
            return GetResult(Default.StringComparison);
        }

        public AssertionResult<PropertyDefinition> GetResult(StringComparison comparison)
        {
            return _context.GetResult(comparison);
        }
    }
}
