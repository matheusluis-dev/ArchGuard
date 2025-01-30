namespace ArchGuard.Contexts
{
    using ArchGuard.Cached;

    internal sealed class RulesContext
    {
        private readonly TypeDefinitionFilterContext _typesFilterContext;
        private readonly TypeDefinitionAssertionContext _typesAssertionContext;

        private readonly TypeFilter _typesFilter;
        private readonly TypeAssertion _typesAssertion;

        public delegate ITypeAssertionRule StartTypeAssertionCallback();

        internal RulesContext(SolutionSearchParameters parameters)
        {
            var solutionCompiled = SolutionReaderCached.CompileSolution(parameters);

            _typesFilterContext = new TypeDefinitionFilterContext(solutionCompiled.Types);
            _typesAssertionContext = new TypeDefinitionAssertionContext(_typesFilterContext);

            _typesFilter = new TypeFilter(_typesFilterContext, StartTypeAssertion);
            _typesAssertion = new TypeAssertion(_typesAssertionContext);
        }

        internal ITypeFilterEntryPoint StartTypeFilter()
        {
            return _typesFilter.Start();
        }

        private ITypeAssertionRule StartTypeAssertion()
        {
            return _typesAssertion.Start();
        }
    }
}
