namespace ArchGuard.Library.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using ArchGuard.Library.Extensions;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public static class AssemblyFilesHelper
    {
        private static readonly List<string> _partials = new List<string>();
        private static readonly List<string> _records = new List<string>();
        private static readonly List<string> _fileScoped = new List<string>();

        private static void AddPartials(IEnumerable<string> partials)
        {
            _partials.AddRange(partials);
        }

        private static void AddRecords(IEnumerable<string> records)
        {
            _records.AddRange(records);
        }

        private static void AddFileScoped(IEnumerable<string> fileScoped)
        {
            _fileScoped.AddRange(fileScoped);
        }

        private static void Load(AssemblySpec assemblySpec)
        {
            AssemblyFilesReaderHelper
                .GetFiles(assemblySpec)
                .ForEach(file =>
                {
                    var code = File.ReadAllText(file.FullName);
                    var syntaxTree = CSharpSyntaxTree.ParseText(
                        code,
                        new CSharpParseOptions()
                            .WithPreprocessorSymbols("NET7_0_OR_GREATER")
                            .WithPreprocessorSymbols("NET5_0_OR_GREATER")
                    );
                    var root = syntaxTree.GetRoot();

                    AddRecords(
                        root.DescendantNodes()
                            .OfType<RecordDeclarationSyntax>()
                            .Select(c => c.GetFullName())
                    );

                    var types = root.DescendantNodes().OfType<TypeDeclarationSyntax>();
                    AddPartials(
                        types
                            .Where(t => t.Modifiers.Any(m => m.IsKind(SyntaxKind.PartialKeyword)))
                            .Select(t => t.GetFullName())
                    );

                    AddFileScoped(
                        types
                            .Where(c => c.Modifiers.Any(m => m.IsKind(SyntaxKind.FileKeyword)))
                            .Select(c => c.GetFullName())
                    );
                });
        }
    }
}
