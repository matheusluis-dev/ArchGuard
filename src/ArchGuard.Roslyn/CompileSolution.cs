#if NET8_0_OR_GREATER
namespace ArchGuard.Roslyn
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.MSBuild;

    public static class CompileSolution
    {
        public static void Compile(string solutionPath, string preprocessor)
        {
            using var workspace = MSBuildWorkspace.Create();
            var solution = workspace.OpenSolutionAsync(solutionPath).Result;

            foreach (
                var project in solution.Projects.Where(p =>
                    p.ParseOptions.PreprocessorSymbolNames.Contains(
                        preprocessor,
                        StringComparer.OrdinalIgnoreCase
                    )
                )
            )
            {
                var compilation = project.GetCompilationAsync().Result;

                var typeMembers = GetAllTypeMembers(
                    compilation.GlobalNamespace,
                    compilation.Assembly
                );

                using var memoryStream = new MemoryStream();
                var result = compilation.Emit(memoryStream);

                if (result.Success)
                {
                    Console.WriteLine($"Project {project.Name} compiled successfully in memory.");
                    // Optionally, you can use the compiled assembly from memoryStream
                    // For example, you can load it into an Assembly object
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    var assembly = System.Reflection.Assembly.Load(memoryStream.ToArray());
                }
                else
                {
                    Console.WriteLine($"Project {project.Name} failed to compile.");
                    foreach (var diagnostic in result.Diagnostics)
                    {
                        Console.WriteLine(diagnostic.ToString());
                    }
                }
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

        public static void ReadAllDocuments(string solutionPath)
        {
            var solutionFilePath = Path.GetFullPath(solutionPath);

            var workspace = MSBuildWorkspace.Create();

            var solution = workspace.OpenSolutionAsync(solutionFilePath).Result;

            var documents = new List<Document>();
            foreach (var projectId in solution.ProjectIds)
            {
                var project = solution.GetProject(projectId);
                foreach (var documentId in project.DocumentIds)
                {
                    var document = solution.GetDocument(documentId);
                    if (document.SupportsSyntaxTree)
                        documents.Add(document);
                }
            }

            var a = documents.First();
            var t = a.GetSyntaxRootAsync().Result;
            var d = t.DescendantNodes().OfType<BaseTypeDeclarationSyntax>();
            var m = t.DescendantNodes().OfType<MethodDeclarationSyntax>();

            var asd = d.First();

            Console.WriteLine();
        }
    }
}
#endif
