namespace ArchGuard.Library.Type
{
    using ArchGuard.Library;
    using ArchGuard.Library.Type.Filters;

    public sealed class Types
    {
        private Types() { }

        public static ITypesFilterStart FromSln(SlnSearchParameters parameters)
        {
            var sln = SolutionReader.CompileSolution(parameters);
            var context = new TypesFilterContext(sln);

            return TypesFilter.Create(context);
        }
    }
}
