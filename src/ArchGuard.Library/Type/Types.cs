namespace ArchGuard.Type
{
    using ArchGuard.Library.Contexts;
    using ArchGuard.Solution;
    using ArchGuard.Type.Filters.EntryPoint;

    public static class Types
    {
        public static ITypeDefinitionFilterEntryPoint InSolution(
            SolutionSearchParameters parameters
        )
        {
            var rulesContext = new RulesContext(parameters);

            return rulesContext.StartTypeFilter();
        }
    }
}
