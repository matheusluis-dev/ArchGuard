namespace ArchGuard
{
    using ArchGuard.Contexts;
    using static ArchGuard.RulesContext;

    public sealed partial class TypeFilter
        : ITypeFilterEntryPoint,
            ITypeFilterRule,
            ITypeFilterSequence
    {
        private readonly TypeFilterContext _context;
        private readonly StartTypeAssertionCallback _startAssertionCallback;

        internal TypeFilter(
            TypeFilterContext context,
            StartTypeAssertionCallback startAssertionCallback
        )
        {
            _context = context;
            _startAssertionCallback = startAssertionCallback;
        }

        internal ITypeFilterEntryPoint Start()
        {
            return this;
        }
    }
}
