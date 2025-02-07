namespace ArchGuard
{
    using ArchGuard.Core.Slice.Contexts;
    using ArchGuard.Core.Slice.Models;

    public sealed class SliceAssertion : ISliceAssertionRule, ISliceAssertionSequence
    {
        private readonly SliceAssertionContext _context;

        public SliceAssertion(SliceAssertionContext context)
        {
            _context = context;
        }

        public ISliceAssertionRule Start()
        {
            return this;
        }

        public ISliceAssertionSequence NotHaveDependenciesBetweenSlices()
        {
            // lol
            return this;
        }

        public SliceAssertionResult GetResult()
        {
            return GetResult(Default.StringComparison);
        }

        public SliceAssertionResult GetResult(StringComparison comparison)
        {
            return _context.GetResult(comparison);
        }
    }
}
