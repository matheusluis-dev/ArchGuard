namespace ArchGuard
{
    using System.Collections.Generic;
    using ArchGuard.Core.Contexts;
    using ArchGuard.Core.Field.Models;

    public sealed partial class FieldFilter : IFieldFilterEntryPoint, IFieldFilterRule, IFieldFilterSequence
    {
        private readonly MemberFilterContext<FieldDefinition> _context;
        private readonly StartFieldAssertionCallback _startFieldAssertionCallback;

        internal FieldFilter(
            MemberFilterContext<FieldDefinition> context,
            StartFieldAssertionCallback startFieldAssertionCallback
        )
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
            return _context.GetElements(comparison);
        }

        public IFieldAssertionRule Should => _startFieldAssertionCallback.Invoke();
    }
}
