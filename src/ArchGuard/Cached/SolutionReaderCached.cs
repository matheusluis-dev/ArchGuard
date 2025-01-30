namespace ArchGuard.Cached
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.MSBuild;

    public static class SolutionReaderCached
    {
        private static readonly Lock _lock = new Lock();

        private static readonly ConcurrentDictionary<
            SolutionSearchParameters,
            SolutionCompilation
        > _cache = new();

        private static string ResolveSlnPath(string path)
        {
            if (File.Exists(path))
                return path;

            return FindFileHelper.GetFileInSolution(path).FullName;
        }

        public static SolutionCompilation CompileSolution(SolutionSearchParameters parameters)
        {
            lock (_lock)
            {
                if (_cache.TryGetValue(parameters, out var sln))
                    return sln;

                using var workspace = MSBuildWorkspace.Create();

                var slnPath = ResolveSlnPath(parameters.SlnPath);
                var solution = workspace.OpenSolutionAsync(slnPath).Result;

                var projects = solution.Projects.Where(p =>
                    p.Name.Equals(parameters.ProjectName, StringComparison.Ordinal)
                    && (
                        string.IsNullOrWhiteSpace(parameters.Preprocessor)
                        || p.ParseOptions?.PreprocessorSymbolNames.Contains(
                            parameters.Preprocessor,
                            StringComparer.OrdinalIgnoreCase
                        ) == true
                    )
                );

                // TODO: create a proper exception for this case
                if (projects?.Any() != true)
                    throw new Exception("Project not found.");

                var types = new List<TypeDefinition>();
                foreach (var project in projects)
                {
                    var compilation = project.GetCompilationAsync().Result;
                    var allTypes = TypesSearchCached.GetAllTypeMembers(
                        compilation!.GlobalNamespace,
                        compilation.Assembly
                    );

                    foreach (var type in allTypes)
                        types.Add(new(project, type));
                }

                var slnCompilation = new SolutionCompilation { Solution = solution, Types = types };

                _cache.TryAdd(parameters, slnCompilation);

                return slnCompilation;
            }
        }
    }
}
