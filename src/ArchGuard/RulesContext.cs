namespace ArchGuard
{
    using ArchGuard.Cached;
    using ArchGuard.Core.Field.Contexts;
    using ArchGuard.Core.Method.Contexts;
    using ArchGuard.Core.Type.Contexts;

    internal delegate ITypeAssertionRule StartTypeAssertionCallback();

    internal delegate IMethodFilterEntryPoint StartMethodFilterCallback();
    internal delegate IMethodAssertionRule StartMethodAssertionCallback();

    internal delegate IFieldFilterEntryPoint StartFieldFilterCallback();
    internal delegate IFieldAssertionRule StartFieldAssertionCallback();

    internal sealed class RulesContext
    {
        private readonly TypeFilterContext _typeFilterContext;
        private readonly TypeAssertionContext _typeAssertionContext;

        private readonly TypeFilter _typeFilter;
        private readonly TypeAssertion _typeAssertion;

        private readonly MethodFilterContext _methodFilterContext;
        private readonly MethodFilter _methodFilter;

        private readonly MethodAssertionContext _methodAssertionContext;
        private readonly MethodAssertion _methodAssertion;

        private readonly FieldFilterContext _fieldFilterContext;
        private readonly FieldFilter _fieldFilter;

        private readonly FieldAssertionContext _fieldAssertionContext;
        private readonly FieldAssertion _fieldAssertion;

        internal RulesContext(SolutionSearchParameters parameters)
        {
            // TODO: technical debt, fix it lol
            var solutionCompiled = SolutionReaderCached.CompileSolution(
                new Core.Models.SolutionSearchParameters
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

            _fieldFilterContext = new FieldFilterContext(_typeFilterContext);
            _fieldAssertionContext = new FieldAssertionContext(_fieldFilterContext);

            _typeFilter = new TypeFilter(
                _typeFilterContext,
                StartTypeAssertion,
                StartMethodFilter,
                StartFieldFilter
            );
            _typeAssertion = new TypeAssertion(_typeAssertionContext);

            _methodFilter = new MethodFilter(_methodFilterContext, StartMethodAssertion);
            _methodAssertion = new MethodAssertion(_methodAssertionContext);

            _fieldFilter = new FieldFilter(_fieldFilterContext, StartFieldAssertion);
            _fieldAssertion = new FieldAssertion(_fieldAssertionContext);
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

        private IFieldFilterEntryPoint StartFieldFilter()
        {
            return _fieldFilter.Start();
        }

        private IFieldAssertionRule StartFieldAssertion()
        {
            return _fieldAssertion.Start();
        }
    }
}
