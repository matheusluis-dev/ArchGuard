namespace ArchGuard.Tests.Common
{
    using ArchGuard.Library.Solution;
    using ArchGuard.Type.Filters.EntryPoint;

    public static class TypesFromMockedAssembly
    {
        public static ITypeDefinitionFilterEntryPoint All =>
            Type.Types.InSolution(
                new SolutionSearchParameters
                {
                    SlnPath = "C:\\Users\\mathe\\source\\github\\me\\ArchGuard\\ArchGuard.sln",
                    Preprocessor = "net9_0",
                    ProjectName = "ArchGuard.Tests.MockedAssembly",
                }
            );
    }
}
