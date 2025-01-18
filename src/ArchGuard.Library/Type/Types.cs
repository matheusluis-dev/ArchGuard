namespace ArchGuard.Library.Type
{
    using ArchGuard.Library;
    using ArchGuard.Library.Cached;
    using ArchGuard.Library.Type.Filters;

    public static class Types
    {
        public static ITypesFilterStart FromSln(SlnSearchParameters parameters)
        {
            var sln = SolutionReaderCached.CompileSolution(parameters);
            var context = new TypesFilterContext(sln);

            return TypesFilter.Create(context);
        }
    }
}
