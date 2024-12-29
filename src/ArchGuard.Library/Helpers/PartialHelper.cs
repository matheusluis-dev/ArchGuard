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

    internal static class PartialHelper
    {
        private static readonly Lazy<IEnumerable<string>> _cache = new Lazy<IEnumerable<string>>(
            Load
        );

        internal static IEnumerable<string> Types => _cache.Value;

        private static IEnumerable<string> Load()
        {
            return ApplicationCSharpFilesHelper.Files.SelectMany(file =>
            {
                var code = File.ReadAllText(file.FullName);
                var syntaxTree = CSharpSyntaxTree.ParseText(code);
                var root = syntaxTree.GetRoot();

                return root.DescendantNodes()
                    .OfType<TypeDeclarationSyntax>()
                    .Where(c => c.Modifiers.Any(m => m.IsKind(SyntaxKind.PartialKeyword)))
                    .Select(c => c.GetFullName());
            });
        }
    }
}
