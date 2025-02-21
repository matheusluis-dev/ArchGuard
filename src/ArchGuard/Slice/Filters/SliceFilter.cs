namespace ArchGuard
{
    using System.Collections.Generic;
    using ArchGuard.Core.Slice.Contexts;
    using ArchGuard.Core.Slice.Models;

    public sealed partial class SliceFilter : ISliceFilterRule, ISliceFilterSequence, IGetSlices
    {
        private readonly SliceFilterContext _context;
        private readonly StartSliceAssertionCallback _startSliceAssertionCallback;

        internal SliceFilter(SliceFilterContext context, StartSliceAssertionCallback startSliceAssertionCallback)
        {
            _context = context;
            _startSliceAssertionCallback = startSliceAssertionCallback;
        }

        internal ISliceFilterRule Start()
        {
            return this;
        }

        public ISliceFilterSequence ByNamespacePrefix(string namespacePrefix)
        {
            ArgumentNullException.ThrowIfNull(namespacePrefix);

            _context.AddSlicesByNamespacePrefix(namespacePrefix);

            return this;
        }

        public IEnumerable<SliceDefinition> GetSlices()
        {
            return GetSlices(Default.StringComparison);
        }

        public IEnumerable<SliceDefinition> GetSlices(StringComparison comparison)
        {
            return _context.GetSlices(comparison);
        }

        public ISliceAssertionRule Should => _startSliceAssertionCallback.Invoke();
    }
}
