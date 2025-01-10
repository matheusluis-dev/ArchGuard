namespace ArchGuard.Roslyn
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.MSBuild;

    public static class SolutionReader
    {
        public static SlnCompilation CompileSolution(SlnSearchParameters parameters)
        {
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
            var compilations = new List<(Project, Compilation)>();
            var types = new Dictionary<Project, IEnumerable<INamedTypeSymbol>>();
            foreach (var project in projects)
            {
                var compilation = project.GetCompilationAsync().Result;

                compilations.Add((project, compilation));
                types.Add(
                    project,
                    GetAllTypeMembers(compilation.GlobalNamespace, compilation.Assembly)
                );
            }

            return new SlnCompilation
            {
                Solution = solution,
                Compilations = compilations,
                Types = types,
            };
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
