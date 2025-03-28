namespace ArchGuard
{
    using ArchGuard.Cached;
    using ArchGuard.Core.Contexts;
    using ArchGuard.Core.Field.Models;
    using ArchGuard.Core.Method.Models;
    using ArchGuard.Core.Models;
    using ArchGuard.Core.Property.Models;
    using ArchGuard.Core.Slice.Contexts;
    using ArchGuard.Core.Type.Models;

    internal delegate ITypeAssertionRule StartTypeAssertionCallback();

    internal delegate IMethodFilterEntryPoint StartMethodFilterCallback();
    internal delegate IMethodAssertionRule StartMethodAssertionCallback();

    internal delegate IFieldFilterEntryPoint StartFieldFilterCallback();
    internal delegate IFieldAssertionRule StartFieldAssertionCallback();

    internal delegate IPropertyFilterEntryPoint StartPropertyFilterCallback();
    internal delegate IPropertyAssertionRule StartPropertyAssertionCallback();

    internal delegate ISliceFilterRule StartSliceFilterCallback();
    internal delegate ISliceAssertionRule StartSliceAssertionCallback();

    internal sealed class IoC
    {
        private delegate ITypeFilterEntryPoint StartTypeFilter();
        private readonly StartTypeFilter _startTypeFilter;

        internal static ITypeFilterEntryPoint Create(string solutionPath, string projectName, string preprocessor)
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

            var typeFilterContext = new Lazy<TypeFilterContext>(() => new(solutionCompiled.TypesFromProjects));

            var typeAssertionContext = new Lazy<AssertionContext<TypeDefinition>>(() => new(typeFilterContext.Value));

            var typeAssertion = new Lazy<TypeAssertion>(() => new(typeAssertionContext.Value));

            var methodFilterContext = new Lazy<MemberFilterContext<MethodDefinition>>(
                () => new(typeFilterContext.Value)
            );

            var fieldFilterContext = new Lazy<MemberFilterContext<FieldDefinition>>(() => new(typeFilterContext.Value));

            var fieldAssertionContext = new Lazy<AssertionContext<FieldDefinition>>(
                () => new(fieldFilterContext.Value)
            );

            var fieldAssertion = new Lazy<FieldAssertion>(() => new(fieldAssertionContext.Value));

            var propertyFilterContext = new Lazy<MemberFilterContext<PropertyDefinition>>(
                () => new(typeFilterContext.Value)
            );

            var propertyAssertionContext = new Lazy<AssertionContext<PropertyDefinition>>(
                () => new(propertyFilterContext.Value)
            );

            var propertyAssertion = new Lazy<PropertyAssertion>(() => new(propertyAssertionContext.Value));

            var methodAssertionContext = new Lazy<AssertionContext<MethodDefinition>>(
                () => new(methodFilterContext.Value)
            );

            var methodAssertion = new Lazy<MethodAssertion>(() => new(methodAssertionContext.Value));

            var methodFilter = new Lazy<MethodFilter>(
                () => new(methodFilterContext.Value, methodAssertion.Value.Start)
            );

            var fieldFilter = new Lazy<FieldFilter>(() => new(fieldFilterContext.Value, fieldAssertion.Value.Start));

            var propertyFilter = new Lazy<PropertyFilter>(
                () => new(propertyFilterContext.Value, propertyAssertion.Value.Start)
            );

            var sliceFilterContext = new Lazy<SliceFilterContext>(() => new(typeFilterContext.Value));

            var sliceAssertionContext = new Lazy<SliceAssertionContext>(() => new(sliceFilterContext.Value));

            var sliceAssertion = new Lazy<SliceAssertion>(() => new(sliceAssertionContext.Value));
            var sliceFilter = new Lazy<SliceFilter>(() => new(sliceFilterContext.Value, sliceAssertion.Value.Start));

            var typeFilter = new Lazy<TypeFilter>(
                () =>
                    new(
                        typeFilterContext.Value,
                        new Lazy<StartTypeAssertionCallback>(typeAssertion.Value.Start),
                        new Lazy<StartMethodFilterCallback>(methodFilter.Value.Start),
                        new Lazy<StartFieldFilterCallback>(fieldFilter.Value.Start),
                        new Lazy<StartPropertyFilterCallback>(propertyFilter.Value.Start),
                        new Lazy<StartSliceFilterCallback>(sliceFilter.Value.Start)
                    )
            );

            _startTypeFilter = typeFilter.Value.Start;
        }
    }
}
