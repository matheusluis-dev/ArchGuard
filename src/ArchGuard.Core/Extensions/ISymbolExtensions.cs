namespace ArchGuard.Core.Extensions
{
    using System;
    using System.Linq;
    using ArchGuard.Core;
    using Microsoft.CodeAnalysis;

    public static class ISymbolExtensions
    {
        public static (SyntaxNode, SemanticModel) GetSemanticModel(
            this ISymbol symbol,
            ProjectDefinition project
        )
        {
            ArgumentNullException.ThrowIfNull(symbol);
            ArgumentNullException.ThrowIfNull(project);

            var syntaxReference =
                symbol.DeclaringSyntaxReferences.FirstOrDefault()
                ?? throw new InvalidOperationException(
                    $"Could not find DeclaringSyntaxReference for {symbol.MetadataName}"
                );

            var syntax =
                syntaxReference.GetSyntax()
                ?? throw new InvalidOperationException(
                    $"Could not get syntax for {symbol.MetadataName}"
                );

            var syntaxTree = syntax.SyntaxTree;
            var semanticModel =
                project.Compilation.GetSemanticModel(syntaxTree)
                ?? throw new InvalidOperationException(
                    $"Could not get Semantic Model for {symbol.MetadataName}"
                );

            return (syntax, semanticModel);
        }
    }
}
