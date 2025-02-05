namespace ArchGuard.Core.Helpers
{
    using Microsoft.CodeAnalysis;

    internal static class SymbolHelper
    {
        internal static bool IsPublic(ISymbol symbol)
        {
            ArgumentNullException.ThrowIfNull(symbol);

            return symbol.DeclaredAccessibility is Accessibility.Public;
        }

        public static bool IsInternal(ISymbol symbol)
        {
            ArgumentNullException.ThrowIfNull(symbol);

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
    }
}
