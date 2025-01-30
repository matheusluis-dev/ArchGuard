namespace ArchGuard.Tests.Common
{
    public static class TypesFromMockedAssembly
    {
        public static ITypeFilterEntryPoint All =>
            ArchGuard.Types.InSolution(
                new SolutionSearchParameters
                {
                    SolutionPath = "C:/Users/mathe/source/github/me/ArchGuard/ArchGuard.sln",
                    Preprocessor = "net9_0",
                    ProjectName = "ArchGuard.Tests.MockedAssembly",
                }
            );
    }
}
