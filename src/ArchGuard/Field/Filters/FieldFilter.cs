namespace ArchGuard
{
    using System.Collections.Generic;
    using ArchGuard.Core.Field.Contexts;
    using ArchGuard.Core.Field.Models;

    public sealed partial class FieldFilter : IFieldFilterEntryPoint, IFieldFilterRule, IFieldFilterSequence
    {
        private readonly FieldFilterContext _context;
        private readonly StartFieldAssertionCallback _startFieldAssertionCallback;

        internal FieldFilter(FieldFilterContext context, StartFieldAssertionCallback startFieldAssertionCallback)
        {
            _context = context;
            _startFieldAssertionCallback = startFieldAssertionCallback;
        }

        internal IFieldFilterEntryPoint Start()
        {
            return this;
        }

        public IEnumerable<FieldDefinition> GetFields()
        {
            return GetFields(Default.StringComparison);
        }

        public IEnumerable<FieldDefinition> GetFields(StringComparison comparison)
        {
            return _context.GetFields(comparison);
        }

        public IFieldAssertionRule Should => _startFieldAssertionCallback.Invoke();
    }
}
