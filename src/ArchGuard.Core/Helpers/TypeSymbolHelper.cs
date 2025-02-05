namespace ArchGuard.Core.Helpers
{
    using ArchGuard.Core.Type.Models;
    using Microsoft.CodeAnalysis;

    internal static class TypeSymbolHelper
    {
        private static List<INamedTypeSymbol> GetContainingTypes(INamedTypeSymbol type)
        {
            ArgumentNullException.ThrowIfNull(type);

            var symbols = new List<INamedTypeSymbol>();
            var current = type.ContainingType;
            while (current is not null)
            {
                symbols.Add(current);
                current = current.ContainingType;
            }

            return symbols;
        }

        private static List<INamedTypeSymbol> GetContainingTypesAndSelf(INamedTypeSymbol type)
        {
            ArgumentNullException.ThrowIfNull(type);

            var symbols = new List<INamedTypeSymbol> { type };
            symbols.AddRange(GetContainingTypes(type));

            return symbols;
        }

        public static bool IsPublic(INamedTypeSymbol type)
        {
            ArgumentNullException.ThrowIfNull(type);

            return GetContainingTypesAndSelf(type).All(SymbolHelper.IsPublic);
        }

        public static bool IsInternal(INamedTypeSymbol type)
        {
            ArgumentNullException.ThrowIfNull(type);

            var typeIsInternal = !type.IsFileLocal && SymbolHelper.IsInternal(type);

            if (!typeIsInternal)
                return false;

            return GetContainingTypes(type)
                .All(type => !type.IsFileLocal && !SymbolHelper.IsPrivateOrProtected(type));
        }

        public static bool IsFileLocal(INamedTypeSymbol type)
        {
            ArgumentNullException.ThrowIfNull(type);

            if (type.IsFileLocal)
                return true;

            var containingTypes = GetContainingTypes(type);

            // File types can't be nested inside any type, even if they are file too
            // But, types of any access modifiers can be nested inside a file type
            // Checks if the first containing type is file scoped
            return containingTypes.Count == 0 || containingTypes[^1].IsFileLocal;
        }

        public static string GetName(INamedTypeSymbol namedTypeSymbol)
        {
            ArgumentNullException.ThrowIfNull(namedTypeSymbol);

            var name = namedTypeSymbol.Name;

            var containingType = namedTypeSymbol.ContainingType;
            while (containingType != null)
            {
                name = $"{containingType.Name}+{name}";
                containingType = containingType.ContainingType;
            }

            if (name.EndsWith('?'))
                name = name[..^1];

            return name;
        }

        public static string GetFullName(INamedTypeSymbol namedTypeSymbol)
        {
            ArgumentNullException.ThrowIfNull(namedTypeSymbol);

            //if (!containingNamespace.IsGlobalNamespace)
            //fullName = $"{containingNamespace}.{fullName}";

            return $"{namedTypeSymbol.ContainingNamespace}.{GetName(namedTypeSymbol)}";
        }

        public static IEnumerable<INamedTypeSymbol> Inheritances(INamedTypeSymbol namedTypeSymbol)
        {
            if (namedTypeSymbol.TypeKind is TypeKind.Interface)
                return namedTypeSymbol.AllInterfaces;

            var baseTypes = new List<INamedTypeSymbol>();

            INamedTypeSymbol? baseType;
            while ((baseType = namedTypeSymbol.BaseType) is not null)
            {
                baseTypes.Add(baseType);
            }

            return baseTypes;
        }
    }
}
