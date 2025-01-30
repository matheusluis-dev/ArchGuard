namespace ArchGuard
{
    using ArchGuard.Contexts;

    public static class Types
    {
        public static ITypeFilterEntryPoint InSolution(SolutionSearchParameters parameters)
        {
            var rulesContext = new RulesContext(parameters);

            return rulesContext.StartTypeFilter();
        }
    }
}
