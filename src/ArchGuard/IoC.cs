namespace ArchGuard
{
    using ArchGuard.Cached;
    using ArchGuard.Core.Field.Contexts;
    using ArchGuard.Core.Method.Contexts;
    using ArchGuard.Core.Models;
    using ArchGuard.Core.Type.Contexts;

    internal delegate ITypeAssertionRule StartTypeAssertionCallback();

    internal delegate IMethodFilterEntryPoint StartMethodFilterCallback();
    internal delegate IMethodAssertionRule StartMethodAssertionCallback();

    internal delegate IFieldFilterEntryPoint StartFieldFilterCallback();
    internal delegate IFieldAssertionRule StartFieldAssertionCallback();

    internal sealed class IoC
    {
        private delegate ITypeFilterEntryPoint StartTypeFilter();
        private readonly StartTypeFilter _startTypeFilter;

        internal static ITypeFilterEntryPoint Create(
            string solutionPath,
            string projectName,
            string preprocessor
        )
        {
            return new IoC(solutionPath, projectName, preprocessor)._startTypeFilter.Invoke();
        }

        private IoC(string solutionPath, string projectName, string preprocessor)
        {
            var dependencyFinder = new DependencyFinder();
            var typesLoader = new TypesLoader();

            var solutionCompiler = new SolutionCompiler(dependencyFinder, typesLoader);

            // TODO: technical debt, fix it lol
            var solutionCompiled = solutionCompiler.Compile(
                new SolutionSearchParameters
                {
                    SolutionPath = solutionPath,
                    ProjectName = projectName,
                    Preprocessor = preprocessor,
                }
            );

            var typeFilterContext = new TypeFilterContext(solutionCompiled.TypesFromProjects);
            var typeAssertionContext = new TypeAssertionContext(typeFilterContext);

            var typeAssertion = new TypeAssertion(typeAssertionContext);

            var methodFilterContext = new MethodFilterContext(typeFilterContext);

            var fieldFilterContext = new FieldFilterContext(typeFilterContext);
            var fieldAssertionContext = new FieldAssertionContext(fieldFilterContext);
            var fieldAssertion = new FieldAssertion(fieldAssertionContext);

            var methodAssertionContext = new MethodAssertionContext(methodFilterContext);
            var methodAssertion = new MethodAssertion(methodAssertionContext);
            var methodFilter = new MethodFilter(methodFilterContext, methodAssertion.Start);

            var fieldFilter = new FieldFilter(fieldFilterContext, fieldAssertion.Start);

            var typeFilter = new TypeFilter(
                typeFilterContext,
                typeAssertion.Start,
                methodFilter.Start,
                fieldFilter.Start
            );

            _startTypeFilter = typeFilter.Start;
        }
    }
}
