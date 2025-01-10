namespace ArchGuard.Roslyn.Type
{
    using ArchGuard.Roslyn;
    using ArchGuard.Roslyn.Type.Filters;

    public sealed class Types
    {
        private Types() { }

        public static ITypesFilterStart FromSln(SlnSearchParameters parameters)
        {
            var sln = SolutionReader.CompileSolution(parameters);
            var context = new TypesFilterContext(sln.AllTypes);

            return TypesFilter.Create(context);
        }
    }
}
