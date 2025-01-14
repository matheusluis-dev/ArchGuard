namespace ArchGuard.Library
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.MSBuild;

    public static class SolutionReader
    {
        private static readonly ConcurrentDictionary<SlnSearchParameters, SlnCompilation> _cache =
            new ConcurrentDictionary<SlnSearchParameters, SlnCompilation>();
        private static readonly Lock _lock = new Lock();

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
                        || p.ParseOptions.PreprocessorSymbolNames.Contains(
                            parameters.Preprocessor,
                            StringComparer.OrdinalIgnoreCase
                        )
                    )
                );

                var types = new List<Type_>();
                foreach (var project in projects)
                {
                    var compilation = project.GetCompilationAsync().Result;
                    var allTypes = GetAllTypeMembers(
                        compilation.GlobalNamespace,
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

        private static List<INamedTypeSymbol> GetAllTypeMembers(
            INamespaceSymbol namespaceSymbol,
            IAssemblySymbol assemblySymbol
        )
        {
            var typeMembers = new List<INamedTypeSymbol>();

            foreach (var typeMember in namespaceSymbol.GetTypeMembers())
            {
                if (typeMember.ContainingAssembly.Equals(assemblySymbol))
                {
                    typeMembers.Add(typeMember);
                    typeMembers.AddRange(GetAllTypeMembers(typeMember, assemblySymbol));
                }
            }

            foreach (var nestedNamespace in namespaceSymbol.GetNamespaceMembers())
            {
                typeMembers.AddRange(GetAllTypeMembers(nestedNamespace, assemblySymbol));
            }

            return typeMembers;
        }

        private static List<INamedTypeSymbol> GetAllTypeMembers(
            INamedTypeSymbol typeSymbol,
            IAssemblySymbol assemblySymbol
        )
        {
            var typeMembers = new List<INamedTypeSymbol>();

            foreach (var nestedType in typeSymbol.GetTypeMembers())
            {
                if (nestedType.ContainingAssembly.Equals(assemblySymbol))
                {
                    typeMembers.Add(nestedType);
                    typeMembers.AddRange(GetAllTypeMembers(nestedType, assemblySymbol));
                }
            }

            return typeMembers;
        }
    }
}
