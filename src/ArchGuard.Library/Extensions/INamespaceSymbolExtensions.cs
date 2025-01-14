namespace ArchGuard.Library.Extensions
{
    using System;
    using Microsoft.CodeAnalysis;

    public static class INamespaceSymbolExtensions
    {
        public static string GetFullName(this INamespaceSymbol namespaceSymbolExtensions)
        {
            ArgumentNullException.ThrowIfNull(namespaceSymbolExtensions);

            var fullName = namespaceSymbolExtensions.Name;

            var containingNamespace = namespaceSymbolExtensions.ContainingNamespace;
            while (containingNamespace?.IsGlobalNamespace == false)
            {
                fullName = $"{containingNamespace.Name}.{fullName}";
                containingNamespace = containingNamespace.ContainingNamespace;
            }

            return fullName;
        }
    }
}
