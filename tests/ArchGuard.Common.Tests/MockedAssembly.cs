namespace ArchGuard.Tests.Common
{
    public static class MockedAssembly
    {
        public static class Methods
        {
            public static class Asynchronous
            {
                public static ITypeFilterEntryPoint Types =>
                    ArchGuard.Types.InSolution(
                        new SolutionSearchParameters
                        {
                            SolutionPath = "ArchGuard.sln",
                            Preprocessor = "net9_0",
                            ProjectName = "ArchGuard.MockedAssembly.Methods.Asynchronous",
                        }
                    );
            }
        }

        public static class Classes
        {
            public static ITypeFilterEntryPoint Types =>
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
            public static ITypeFilterEntryPoint Types =>
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
            public static ITypeFilterEntryPoint Types =>
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
            public static ITypeFilterEntryPoint Types =>
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
            public static ITypeFilterEntryPoint Types =>
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
            public static ITypeFilterEntryPoint Types =>
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
