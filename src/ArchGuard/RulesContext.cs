namespace ArchGuard
{
    using ArchGuard.Cached;
    using ArchGuard.Contexts;

    internal sealed class RulesContext
    {
        private readonly TypeFilterContext _typeFilterContext;
        private readonly TypeAssertionContext _typeAssertionContext;

        private readonly TypeFilter _typeFilter;
        private readonly TypeAssertion _typeAssertion;

        public delegate ITypeAssertionRule StartTypeAssertionCallback();

        private readonly MethodFilterContext _methodFilterContext;
        private readonly MethodFilter _methodFilter;

        private readonly MethodAssertionContext _methodAssertionContext;
        private readonly MethodAssertion _methodAssertion;

        public delegate IMethodFilterEntryPoint StartMethodFilterCallback();
        public delegate IMethodAssertionRule StartMethodAssertionCallback();

        internal RulesContext(SolutionSearchParameters parameters)
        {
            var solutionCompiled = SolutionReaderCached.CompileSolution(
                new Kernel.Models.SolutionSearchParameters
                {
                    SolutionPath = parameters.SolutionPath,
                    ProjectName = parameters.ProjectName,
                    Preprocessor = parameters.Preprocessor,
                }
            );

            _typeFilterContext = new TypeFilterContext(solutionCompiled.Types);
            _typeAssertionContext = new TypeAssertionContext(_typeFilterContext);

            _methodFilterContext = new MethodFilterContext(_typeFilterContext);
            _methodAssertionContext = new MethodAssertionContext(_methodFilterContext);

            _typeFilter = new TypeFilter(_typeFilterContext, StartTypeAssertion, StartMethodFilter);
            _typeAssertion = new TypeAssertion(_typeAssertionContext);

            _methodFilter = new MethodFilter(_methodFilterContext, StartMethodAssertion);
            _methodAssertion = new MethodAssertion(_methodAssertionContext);
        }

        internal ITypeFilterEntryPoint StartTypeFilter()
        {
            return _typeFilter.Start();
        }

        private ITypeAssertionRule StartTypeAssertion()
        {
            return _typeAssertion.Start();
        }

        private IMethodFilterEntryPoint StartMethodFilter()
        {
            return _methodFilter.Start();
        }

        private IMethodAssertionRule StartMethodAssertion()
        {
            return _methodAssertion.Start();
        }
    }
}
