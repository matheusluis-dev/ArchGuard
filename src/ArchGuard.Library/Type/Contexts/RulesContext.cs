namespace ArchGuard.Library.Type.Contexts
{
    using ArchGuard.Library.Cached;
    using ArchGuard.Library.Type.Assertions;
    using ArchGuard.Library.Type.Filters;

    internal sealed class RulesContext
    {
        private readonly TypeDefinitionFilterContext _typesFilterContext;
        private readonly TypeDefinitionAssertionContext _typesAssertionContext;

        private readonly TypeDefinitionFilter _typesFilter;
        private readonly TypesAssertion _typesAssertion;

        public delegate ITypesAssertionCondition StartTypeAssertionCallback();

        internal RulesContext(SlnSearchParameters parameters)
        {
            var sln = SolutionReaderCached.CompileSolution(parameters);

            _typesFilterContext = new TypeDefinitionFilterContext(sln.Types);
            _typesAssertionContext = new TypeDefinitionAssertionContext(_typesFilterContext);

            _typesFilter = new TypeDefinitionFilter(_typesFilterContext, StartTypeAssertion);
            _typesAssertion = new TypesAssertion(_typesAssertionContext);
        }

        internal ITypeDefinitionFilterEntryPoint StartTypeFilter()
        {
            return _typesFilter.Start();
        }

        private ITypesAssertionCondition StartTypeAssertion()
        {
            return _typesAssertion.Start();
        }
    }
}
