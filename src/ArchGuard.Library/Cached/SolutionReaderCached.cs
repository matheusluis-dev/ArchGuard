namespace ArchGuard.Library.Cached
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.MSBuild;

    public static class SolutionReaderCached
    {
        private static readonly Lock _lock = new Lock();

        private static readonly ConcurrentDictionary<SlnSearchParameters, SlnCompilation> _cache =
            new();

        public static SlnCompilation CompileSolution(SlnSearchParameters parameters)
        {
            lock (_lock)
            {
                if (_cache.TryGetValue(parameters, out var sln))
                    return sln;

                using var workspace = MSBuildWorkspace.Create();
                var solution = workspace.OpenSolutionAsync(parameters.SlnPath).Result;

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

                var slnCompilation = new SlnCompilation { Solution = solution, Types = types };

                _cache.TryAdd(parameters, slnCompilation);

                return slnCompilation;
            }
        }
    }
}
