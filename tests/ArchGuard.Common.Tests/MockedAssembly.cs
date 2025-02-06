namespace ArchGuard.Tests.Common
{
    public static class MockedAssembly
    {
        public static class HaveDependencyOnNamespace
        {
            public static ITypeFilterEntryPoint Types =>
                ArchGuard.Types.InSolution(
                    "ArchGuard.sln",
                    "ArchGuard.MockedAssembly.HaveDependencyOnNamespace",
                    "net9_0"
                );
        }

        public static class Inherit
        {
            public static ITypeFilterEntryPoint Types =>
                ArchGuard.Types.InSolution(
                    "ArchGuard.sln",
                    "ArchGuard.MockedAssembly.Inherit",
                    "net9_0"
                );
        }

        public static class AccessModifiers
        {
            public static class File
            {
                public static ITypeFilterEntryPoint Types =>
                    ArchGuard.Types.InSolution(
                        "ArchGuard.sln",
                        "ArchGuard.MockedAssembly.AccessModifiers.File",
                        "net9_0"
                    );
            }

            public static class Internal
            {
                public static ITypeFilterEntryPoint Types =>
                    ArchGuard.Types.InSolution(
                        "ArchGuard.sln",
                        "ArchGuard.MockedAssembly.AccessModifiers.Internal",
                        "net9_0"
                    );
            }

            public static class Public
            {
                public static ITypeFilterEntryPoint Types =>
                    ArchGuard.Types.InSolution(
                        "ArchGuard.sln",
                        "ArchGuard.MockedAssembly.AccessModifiers.Public",
                        "net9_0"
                    );
            }
        }

        public static class Methods
        {
            public static class Asynchronous
            {
                public static ITypeFilterEntryPoint Types =>
                    ArchGuard.Types.InSolution(
                        "ArchGuard.sln",
                        "ArchGuard.MockedAssembly.Methods.Asynchronous",
                        "net9_0"
                    );
            }

            public static class Static
            {
                public static ITypeFilterEntryPoint Types =>
                    ArchGuard.Types.InSolution(
                        "ArchGuard.sln",
                        "ArchGuard.MockedAssembly.Methods.Static",
                        "net9_0"
                    );
            }
        }

        public static class Classes
        {
            public static ITypeFilterEntryPoint Types =>
                ArchGuard.Types.InSolution(
                    "ArchGuard.sln",
                    "ArchGuard.MockedAssembly.Classes",
                    "net9_0"
                );
        }

        public static class Enums
        {
            public static ITypeFilterEntryPoint Types =>
                ArchGuard.Types.InSolution(
                    "ArchGuard.sln",
                    "ArchGuard.MockedAssembly.Enums",
                    "net9_0"
                );
        }

        public static class Interfaces
        {
            public static ITypeFilterEntryPoint Types =>
                ArchGuard.Types.InSolution(
                    "ArchGuard.sln",
                    "ArchGuard.MockedAssembly.Interfaces",
                    "net9_0"
                );
        }

        public static class Records
        {
            public static ITypeFilterEntryPoint Types =>
                ArchGuard.Types.InSolution(
                    "ArchGuard.sln",
                    "ArchGuard.MockedAssembly.Records",
                    "net9_0"
                );
        }

        public static class RecordStructs
        {
            public static ITypeFilterEntryPoint Types =>
                ArchGuard.Types.InSolution(
                    "ArchGuard.sln",
                    "ArchGuard.MockedAssembly.RecordStructs",
                    "net9_0"
                );
        }

        public static class Structs
        {
            public static ITypeFilterEntryPoint Types =>
                ArchGuard.Types.InSolution(
                    "ArchGuard.sln",
                    "ArchGuard.MockedAssembly.Structs",
                    "net9_0"
                );
        }
    }
}
