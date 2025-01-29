namespace ArchGuard.Extensions
{
    using System;
    using Microsoft.CodeAnalysis;

    public static class INamespaceSymbolExtensions
    {
        public static string GetFullName(this INamespaceSymbol namespaceSymbol)
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
