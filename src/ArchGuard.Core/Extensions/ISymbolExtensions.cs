namespace ArchGuard.Extensions
{
    using System;
    using System.Linq;
    using Microsoft.CodeAnalysis;

    public static class ISymbolExtensions
    {
        public static bool IsPublic(this ISymbol symbol)
        {
            ArgumentNullException.ThrowIfNull(symbol);

            return symbol.DeclaredAccessibility is Accessibility.Public;
        }

        public static bool IsInternal(this ISymbol symbol)
        {
            ArgumentNullException.ThrowIfNull(symbol);

            return symbol.DeclaredAccessibility
                is Accessibility.Internal
                    or Accessibility.Friend
                    or Accessibility.ProtectedOrFriend
                    or Accessibility.ProtectedOrInternal;
        }

        public static bool IsProtected(this ISymbol symbol)
        {
            ArgumentNullException.ThrowIfNull(symbol);

            return symbol.DeclaredAccessibility
                is Accessibility.Protected
                    or Accessibility.ProtectedOrInternal
                    or Accessibility.ProtectedOrFriend
                    or Accessibility.ProtectedAndInternal
                    or Accessibility.ProtectedAndFriend;
        }

        public static bool IsPrivate(this ISymbol symbol)
        {
            ArgumentNullException.ThrowIfNull(symbol);

            return symbol.DeclaredAccessibility is Accessibility.Private;
        }

        public static bool IsPrivateOrProtected(this ISymbol symbol)
        {
            ArgumentNullException.ThrowIfNull(symbol);

            return symbol.DeclaredAccessibility is Accessibility.Private or Accessibility.Protected;
        }

        public static bool HasDeclaringSyntaxReferences(this ISymbol symbol)
        {
            ArgumentNullException.ThrowIfNull(symbol);

            return symbol.DeclaringSyntaxReferences.Any();
        }

        public static (SyntaxNode, SemanticModel) GetSemanticModel(
            this ISymbol symbol,
            Project project
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

            var compilation = project.GetCompilationAsync().Result;

            var syntaxTree = syntax.SyntaxTree;
            var semanticModel =
                compilation?.GetSemanticModel(syntaxTree)
                ?? throw new InvalidOperationException(
                    $"Could not get Semantic Model for {symbol.MetadataName}"
                );

            return (syntax, semanticModel);
        }
    }
}
