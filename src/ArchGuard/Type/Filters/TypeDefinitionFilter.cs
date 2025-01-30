namespace ArchGuard
{
    using ArchGuard.Contexts;
    using static ArchGuard.Contexts.RulesContext;

    public sealed partial class TypeDefinitionFilter
        : ITypeDefinitionFilterEntryPoint,
            ITypeDefinitionFilterRule,
            ITypeDefinitionFilterSequence
    {
        private readonly TypeDefinitionFilterContext _context;
        private readonly StartTypeAssertionCallback _startAssertionCallback;

        internal TypeDefinitionFilter(
            TypeDefinitionFilterContext context,
            StartTypeAssertionCallback startAssertionCallback
        )
        {
            _context = context;
            _startAssertionCallback = startAssertionCallback;
        }

        internal ITypeDefinitionFilterEntryPoint Start()
        {
            return this;
        }
    }
}
