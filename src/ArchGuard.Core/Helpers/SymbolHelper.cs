namespace ArchGuard.Core.Helpers
{
    using Microsoft.CodeAnalysis;

    internal static class SymbolHelper
    {
        internal static bool IsPublic(ISymbol symbol)
        {
            ArgumentNullException.ThrowIfNull(symbol);

            if (symbol is INamedTypeSymbol)
                throw new ArgumentException($"{symbol} must not be {nameof(INamedTypeSymbol)}.");

            return symbol.DeclaredAccessibility is Accessibility.Public;
        }

        public static bool IsInternal(ISymbol symbol)
        {
            ArgumentNullException.ThrowIfNull(symbol);

            if (symbol is INamedTypeSymbol)
                throw new ArgumentException($"{symbol} must not be {nameof(INamedTypeSymbol)}.");

            return symbol.DeclaredAccessibility
                is Accessibility.Internal
                    or Accessibility.Friend
                    or Accessibility.ProtectedOrFriend
                    or Accessibility.ProtectedOrInternal;
        }

        public static bool IsProtected(ISymbol symbol)
        {
            ArgumentNullException.ThrowIfNull(symbol);

            return symbol.DeclaredAccessibility
                is Accessibility.Protected
                    or Accessibility.ProtectedOrInternal
                    or Accessibility.ProtectedOrFriend
                    or Accessibility.ProtectedAndInternal
                    or Accessibility.ProtectedAndFriend;
        }

        public static bool IsPrivate(ISymbol symbol)
        {
            ArgumentNullException.ThrowIfNull(symbol);

            return symbol.DeclaredAccessibility is Accessibility.Private;
        }

        public static bool IsPrivateOrProtected(ISymbol symbol)
        {
            ArgumentNullException.ThrowIfNull(symbol);

            return symbol.DeclaredAccessibility is Accessibility.Private or Accessibility.Protected;
        }

        public static bool HasDeclaringSyntaxReferences(ISymbol symbol)
        {
            ArgumentNullException.ThrowIfNull(symbol);

            return symbol.DeclaringSyntaxReferences.Any();
        }

        public static (SyntaxNode, SemanticModel) GetSemanticModel(ISymbol symbol, ProjectDefinition project)
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
                ?? throw new InvalidOperationException($"Could not get syntax for {symbol.MetadataName}");

            var syntaxTree = syntax.SyntaxTree;
            var semanticModel =
                project.Compilation.GetSemanticModel(syntaxTree)
                ?? throw new InvalidOperationException($"Could not get Semantic Model for {symbol.MetadataName}");

            return (syntax, semanticModel);
        }
    }
}
