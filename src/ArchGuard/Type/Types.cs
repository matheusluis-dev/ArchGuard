namespace ArchGuard
{
    public static class Types
    {
        public static ITypeFilterEntryPoint InSolution(SolutionSearchParameters parameters)
        {
            var rulesContext = new RulesContext(parameters);

            return rulesContext.StartTypeFilter();
        }
    }
}
