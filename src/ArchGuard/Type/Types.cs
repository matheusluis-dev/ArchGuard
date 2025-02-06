namespace ArchGuard
{
    public static class Types
    {
        public static ITypeFilterEntryPoint InSolution(
            string solutionPath,
            string projectName,
            string preprocessor
        )
        {
            return IoC.Create(solutionPath, projectName, preprocessor);
        }
    }
}
