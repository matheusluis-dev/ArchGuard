namespace ArchGuard.Tests.Common
{
    public static class TypesFromMockedAssembly
    {
        public static ITypeFilterEntryPoint All =>
            ArchGuard.Types.InSolution(
                "C:/Users/mathe/source/github/me/ArchGuard/ArchGuard.sln",
                "net9_0",
                "ArchGuard.Tests.MockedAssembly"
            );
    }
}
