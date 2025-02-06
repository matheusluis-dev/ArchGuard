namespace ArchGuard.Core.Helpers
{
    using Microsoft.CodeAnalysis;

    public static class NamespaceSymbolHelper
    {
        public static string GetFullName(INamespaceSymbol namespaceSymbol)
        {
            ArgumentNullException.ThrowIfNull(namespaceSymbol);

            var fullName = namespaceSymbol.Name;

            var containingNamespace = namespaceSymbol.ContainingNamespace;
            while (containingNamespace?.IsGlobalNamespace == false)
            {
                fullName = $"{containingNamespace.Name}.{fullName}";
                containingNamespace = containingNamespace.ContainingNamespace;
            }

            return fullName;
        }
    }
}
