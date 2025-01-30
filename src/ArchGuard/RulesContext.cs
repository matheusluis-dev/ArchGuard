namespace ArchGuard.Contexts
{
    using ArchGuard.Cached;

    internal sealed class RulesContext
    {
        private readonly TypeDefinitionFilterContext _typesFilterContext;
        private readonly TypeDefinitionAssertionContext _typesAssertionContext;

        private readonly TypeDefinitionFilter _typesFilter;
        private readonly TypeDefinitionAssertion _typesAssertion;

        public delegate ITypeDefinitionAssertionRule StartTypeAssertionCallback();

        internal RulesContext(SolutionSearchParameters parameters)
        {
            var solutionCompiled = SolutionReaderCached.CompileSolution(parameters);

            _typesFilterContext = new TypeDefinitionFilterContext(solutionCompiled.Types);
            _typesAssertionContext = new TypeDefinitionAssertionContext(_typesFilterContext);

            _typesFilter = new TypeDefinitionFilter(_typesFilterContext, StartTypeAssertion);
            _typesAssertion = new TypeDefinitionAssertion(_typesAssertionContext);
        }

        internal ITypeDefinitionFilterEntryPoint StartTypeFilter()
        {
            return _typesFilter.Start();
        }

        private ITypeDefinitionAssertionRule StartTypeAssertion()
        {
            return _typesAssertion.Start();
        }
    }
}
