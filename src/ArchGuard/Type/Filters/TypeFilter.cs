namespace ArchGuard
{
    using ArchGuard.Contexts;
    using static ArchGuard.Contexts.RulesContext;

    public sealed partial class TypeFilter
        : ITypeFilterEntryPoint,
            ITypeFilterRule,
            ITypeFilterSequence
    {
        private readonly TypeDefinitionFilterContext _context;
        private readonly StartTypeAssertionCallback _startAssertionCallback;

        internal TypeFilter(
            TypeDefinitionFilterContext context,
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
