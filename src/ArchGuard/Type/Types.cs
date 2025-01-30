namespace ArchGuard
{
    using ArchGuard.Contexts;

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
