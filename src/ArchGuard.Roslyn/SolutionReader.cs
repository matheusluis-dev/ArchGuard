namespace ArchGuard.Roslyn
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.MSBuild;

    public static class SolutionReader
    {
        public static Solution GetSolution(SolutionSearchParameters parameters)
        {
            using var workspace = MSBuildWorkspace.Create();
            return workspace.OpenSolutionAsync(parameters.SlnPath).Result;
        }

        public static IEnumerable<Project> GetProjects(SolutionSearchParameters parameters)
        {

        }

        public static IEnumerable<Compilation> CompileSolution(SolutionSearchParameters parameters)
        {
            return Compilations();

            IEnumerable<Compilation> Compilations()
            {
                using var workspace = MSBuildWorkspace.Create();
                var solution = workspace.OpenSolutionAsync(parameters.SlnPath).Result;

                foreach (
                    var project in solution.Projects.Where(p =>
                        !string.IsNullOrWhiteSpace(parameters.Preprocessor)
                        || p.ParseOptions.PreprocessorSymbolNames.Contains(
                            parameters.Preprocessor,
                            StringComparer.OrdinalIgnoreCase
                        )
                    )
                )
                {
                    yield return project.GetCompilationAsync().Result;
                }
            }
        }
    }
}
