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

    internal static class FileAccessModifierHelper
    {
        internal static IEnumerable<string> GetFileScopedTypes(AssemblySpec assemblySpecification)
        {
            return AssemblyFilesHelper
                .GetFiles(assemblySpecification)
                .SelectMany(file =>
                {
                    var code = File.ReadAllText(file.FullName);
                    var syntaxTree = CSharpSyntaxTree.ParseText(
                        code,
                        // TODO find a way to treat preprocessors and stuff
                        new CSharpParseOptions().WithPreprocessorSymbols("NET7_0_OR_GREATER")
                    );
                    var root = syntaxTree.GetRoot();

                    return root.DescendantNodes()
                        .OfType<TypeDeclarationSyntax>()
                        .Where(c => c.Modifiers.Any(m => m.IsKind(SyntaxKind.FileKeyword)))
                        .Select(c => c.GetFullName())
                        .Distinct(StringComparer.Ordinal);
                });
        }
    }
}
