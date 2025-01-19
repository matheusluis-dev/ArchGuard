namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Contexts;
    using static ArchGuard.Library.Type.Contexts.RulesContext;

    public sealed partial class TypeDefinitionFilter
        : ITypeDefinitionFilterEntryPoint,
            ITypeDefinitionFilterRule,
            ITypeDefinitionFilterSequence
    {
        private readonly TypesFilterContext _context;
        private readonly StartTypeAssertionCallback _startAssertionCallback;

        internal TypeDefinitionFilter(
            TypesFilterContext context,
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
