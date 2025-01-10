namespace ArchGuard.Library.Extensions
{
    using System;
    using System.Linq;
    using Microsoft.CodeAnalysis;

    public static class INamedTypeSymbolExtensions
    {
        public static string GetName(this INamedTypeSymbol iNamedTypeSymbol)
        {
            var name = iNamedTypeSymbol.Name;
            var containingType = iNamedTypeSymbol.ContainingType;

            while (containingType != null)
            {
                name = $"{containingType.Name}+{name}";
                containingType = containingType.ContainingType;
            }

            return name;
        }

        public static string GetFullName(this INamedTypeSymbol iNamedTypeSymbol)
        {
            var fullName = iNamedTypeSymbol.GetName();

            var containingNamespace = iNamedTypeSymbol.ContainingNamespace;
            if (!containingNamespace.IsGlobalNamespace)
                fullName = $"{containingNamespace}.{fullName}";

            return fullName;
        }

        public static bool Inherit(this INamedTypeSymbol iNamedTypeSymbol, params Type[] types)
        {
            var baseType = iNamedTypeSymbol.BaseType;

            while (baseType != null)
            {
                if (
                    types
                        .Select(t => t.GetFullName())
                        .Contains(baseType.GetFullName(), StringComparer.CurrentCulture)
                )
                {
                    return true;
                }
                baseType = baseType.BaseType;
            }

            return false;
        }
    }
}
