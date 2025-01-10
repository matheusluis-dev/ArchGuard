namespace ArchGuard.Library.Extensions
{
    using Microsoft.CodeAnalysis;

    public static class INamespaceSymbolExtensions
    {
        public static string GetFullName(this INamespaceSymbol iNamespaceSymbolExtensions)
        {
            var fullName = iNamespaceSymbolExtensions.Name;

            var containingNamespace = iNamespaceSymbolExtensions.ContainingNamespace;
            while (containingNamespace is not null && !containingNamespace.IsGlobalNamespace)
            {
                fullName = $"{containingNamespace.Name}.{fullName}";
                containingNamespace = containingNamespace.ContainingNamespace;
            }

            return fullName;
        }
    }
}
