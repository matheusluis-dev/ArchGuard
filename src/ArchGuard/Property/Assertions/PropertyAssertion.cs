namespace ArchGuard
{
    using ArchGuard.Core.Property.Contexts;
    using ArchGuard.Core.Property.Models;

    public sealed partial class PropertyAssertion : IPropertyAssertionRule, IPropertyAssertionSequence
    {
        private readonly PropertyAssertionContext _context;

        public PropertyAssertion(PropertyAssertionContext context)
        {
            _context = context;
        }

        public IPropertyAssertionRule Start()
        {
            return this;
        }

        public PropertyAssertionResult GetResult()
        {
            return GetResult(Default.StringComparison);
        }

        public PropertyAssertionResult GetResult(StringComparison comparison)
        {
            return _context.GetResult(comparison);
        }
    }
}
