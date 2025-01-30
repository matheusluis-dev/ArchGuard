namespace ArchGuard.Tests.Common
{
    public static class TypesFromMockedAssembly
    {
        public static ITypeDefinitionFilterEntryPoint All =>
            ArchGuard.Types.InSolution(
                new SolutionSearchParameters
                {
                    SlnPath = "C:/Users/mathe/source/github/me/ArchGuard/ArchGuard.sln",
                    Preprocessor = "net9_0",
                    ProjectName = "ArchGuard.Tests.MockedAssembly",
                }
            );
    }
}
