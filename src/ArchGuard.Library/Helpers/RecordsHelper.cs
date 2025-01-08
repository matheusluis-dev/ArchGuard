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

    internal static class RecordsHelper
    {
        internal static IEnumerable<string> GetRecords(AssemblySpec assemblySpecification)
        {
            return AssemblyFilesHelper
                .GetFiles(assemblySpecification)
                .SelectMany(file =>
                {
                    var code = File.ReadAllText(file.FullName);
                    var syntaxTree = CSharpSyntaxTree.ParseText(
                        code,
                        // TODO find a way to treat preprocessors and stuff
                        new CSharpParseOptions().WithPreprocessorSymbols("NET5_0_OR_GREATER")
                    );
                    var root = syntaxTree.GetRoot();

                    return root.DescendantNodes()
                        .OfType<RecordDeclarationSyntax>()
                        .Select(c => c.GetFullName())
                        .Distinct(StringComparer.Ordinal);
                });
        }
    }
}
