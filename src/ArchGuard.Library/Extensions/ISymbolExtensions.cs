namespace ArchGuard.Library.Extensions
{
    using Microsoft.CodeAnalysis;

    public static class ISymbolExtensions
    {
        public static bool IsPrivateOrProtected(this ISymbol symbol)
        {
            return symbol.DeclaredAccessibility == Accessibility.Private
                || symbol.DeclaredAccessibility == Accessibility.Protected;
        }
    }
}
