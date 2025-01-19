namespace ArchGuard.Library.Type
{
    using ArchGuard.Library;
    using ArchGuard.Library.Type.Contexts;
    using ArchGuard.Library.Type.Filters;

    public static class Types
    {
        public static ITypesFilterStart FromSln(SlnSearchParameters parameters)
        {
            var rulesContext = new RulesContext(parameters);

            return rulesContext.StartTypeFilter();
        }

        //public static ITypesFilterStart FromSln(SlnSearchParameters parameters)
        //{
        //    var sln = SolutionReaderCached.CompileSolution(parameters);
        //    var context = new TypesFilterContext(sln);

        //    return TypesFilter.Create(context);
        //}
    }
}
