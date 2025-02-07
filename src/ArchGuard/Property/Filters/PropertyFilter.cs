namespace ArchGuard
{
    using System.Collections.Generic;
    using ArchGuard.Core.Property.Contexts;
    using ArchGuard.Core.Property.Models;

    public sealed partial class PropertyFilter
        : IPropertyFilterEntryPoint,
            IPropertyFilterRule,
            IPropertyFilterSequence
    {
        private readonly PropertyFilterContext _context;
        private readonly StartPropertyAssertionCallback _startPropertyAssertionCallback;

        internal PropertyFilter(
            PropertyFilterContext context,
            StartPropertyAssertionCallback startPropertyAssertionCallback
        )
        {
            _context = context;
            _startPropertyAssertionCallback = startPropertyAssertionCallback;
        }

        internal IPropertyFilterEntryPoint Start()
        {
            return this;
        }

        public IEnumerable<PropertyDefinition> GetProperties()
        {
            return GetProperties(Default.StringComparison);
        }

        public IEnumerable<PropertyDefinition> GetProperties(StringComparison comparison)
        {
            return _context.GetProperties(comparison);
        }

        public IPropertyAssertionRule Should => _startPropertyAssertionCallback.Invoke();
    }
}
