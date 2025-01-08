namespace ArchGuard.Library.Helpers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public static class AssemblyFilesHelper
    {
        internal static IEnumerable<TypeSpecRoslyn> Load(AssemblySpec assemblySpec)
        {
            return AssemblyFilesReaderHelper
                .GetFiles(assemblySpec)
                .SelectMany(file =>
                {
                    var code = File.ReadAllText(file.FullName);
                    var syntaxTree = CSharpSyntaxTree.ParseText(
                        code,
                        new CSharpParseOptions()
                            .WithPreprocessorSymbols("NET7_0_OR_GREATER")
                            .WithPreprocessorSymbols("NET5_0_OR_GREATER")
                    );
                    var root = syntaxTree.GetRoot();

                    return root.DescendantNodes()
                        .OfType<TypeDeclarationSyntax>()
                        .Select(t => new TypeSpecRoslyn(t, file.FullName));
                })
                .Distinct();
        }
    }
}
