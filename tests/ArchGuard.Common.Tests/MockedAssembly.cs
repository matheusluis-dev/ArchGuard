namespace ArchGuard.Tests.Common
{
    using System;

    public static class MockedAssembly
    {
        public static class Classes
        {
            public static ITypeDefinitionFilterEntryPoint Types =>
                ArchGuard.Types.InSolution(
                    new SolutionSearchParameters
                    {
                        SlnPath = "C:/Users/mathe/source/github/me/ArchGuard/ArchGuard.sln",
                        Preprocessor = "net9_0",
                        ProjectName = "ArchGuard.MockedAssembly.Classes",
                    }
                );
        }

        public static class Enums
        {
            public static ITypeDefinitionFilterEntryPoint Types =>
                ArchGuard.Types.InSolution(
                    new SolutionSearchParameters
                    {
                        SlnPath = "C:/Users/mathe/source/github/me/ArchGuard/ArchGuard.sln",
                        Preprocessor = "net9_0",
                        ProjectName = "ArchGuard.MockedAssembly.Enums",
                    }
                );
        }
    }
}
