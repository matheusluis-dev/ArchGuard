namespace ArchGuard.Library.Type
{
    using ArchGuard.Library.Contexts;
    using ArchGuard.Library.Solution;
    using ArchGuard.Library.Type.Filters;

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
