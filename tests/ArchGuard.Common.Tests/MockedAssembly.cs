namespace ArchGuard.Tests.Common
{
    public static class MockedAssembly
    {
        public static class Classes
        {
            public static ITypeDefinitionFilterEntryPoint Types =>
                ArchGuard.Types.InSolution(
                    new SolutionSearchParameters
                    {
                        SolutionPath = "ArchGuard.sln",
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
                        SolutionPath = "ArchGuard.sln",
                        Preprocessor = "net9_0",
                        ProjectName = "ArchGuard.MockedAssembly.Enums",
                    }
                );
        }

        public static class Interfaces
        {
            public static ITypeDefinitionFilterEntryPoint Types =>
                ArchGuard.Types.InSolution(
                    new SolutionSearchParameters
                    {
                        SolutionPath = "ArchGuard.sln",
                        Preprocessor = "net9_0",
                        ProjectName = "ArchGuard.MockedAssembly.Interfaces",
                    }
                );
        }

        public static class Records
        {
            public static ITypeDefinitionFilterEntryPoint Types =>
                ArchGuard.Types.InSolution(
                    new SolutionSearchParameters
                    {
                        SolutionPath = "ArchGuard.sln",
                        Preprocessor = "net9_0",
                        ProjectName = "ArchGuard.MockedAssembly.Records",
                    }
                );
        }

        public static class RecordStructs
        {
            public static ITypeDefinitionFilterEntryPoint Types =>
                ArchGuard.Types.InSolution(
                    new SolutionSearchParameters
                    {
                        SolutionPath = "ArchGuard.sln",
                        Preprocessor = "net9_0",
                        ProjectName = "ArchGuard.MockedAssembly.RecordStructs",
                    }
                );
        }

        public static class Structs
        {
            public static ITypeDefinitionFilterEntryPoint Types =>
                ArchGuard.Types.InSolution(
                    new SolutionSearchParameters
                    {
                        SolutionPath = "ArchGuard.sln",
                        Preprocessor = "net9_0",
                        ProjectName = "ArchGuard.MockedAssembly.Structs",
                    }
                );
        }
    }
}
