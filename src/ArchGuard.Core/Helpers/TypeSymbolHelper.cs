namespace ArchGuard.Core.Helpers
{
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

            var name = namedTypeSymbol.MetadataName;

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

        public static string GetFullName(ITypeSymbol typeSymbol)
        {
            // TODO: no comments, it's obvious
            if (typeSymbol is not INamedTypeSymbol namedTypeSymbol)
            {
                throw new ArgumentException(
                    $"{nameof(typeSymbol)} must be {nameof(INamedTypeSymbol)}."
                );
            }

            return GetName(namedTypeSymbol);
        }

        public static string GetFullName(INamedTypeSymbol namedTypeSymbol)
        {
            ArgumentNullException.ThrowIfNull(namedTypeSymbol);

            return $"{namedTypeSymbol.ContainingNamespace}.{GetName(namedTypeSymbol)}";
        }

        public static IEnumerable<INamedTypeSymbol> GetTypeInheritances(
            INamedTypeSymbol namedTypeSymbol
        )
        {
            var types = new HashSet<INamedTypeSymbol>(SymbolEqualityComparer.Default);

            var baseType = namedTypeSymbol.BaseType;
            while (baseType is not null)
            {
                types.Add(baseType);
                baseType = baseType.BaseType;
            }

            return types;
        }

        public static bool IsImmutable(INamedTypeSymbol namedTypeSymbol)
        {
            ArgumentNullException.ThrowIfNull(namedTypeSymbol);

            var list = new List<INamedTypeSymbol> { namedTypeSymbol };

            var baseType = namedTypeSymbol.BaseType;
            while (baseType is not null)
            {
                if (!baseType.Name.Equals("object", StringComparison.OrdinalIgnoreCase))
                    list.Add(baseType);

                baseType = baseType.BaseType;
            }

            return list.All(IsImmutable);

            static bool IsImmutable(INamedTypeSymbol t)
            {
                var allFieldsReadonly = t.GetMembers()
                    .OfType<IFieldSymbol>()
                    .All(field => field.IsReadOnly || field.IsConst);

                var allPropertiesReadonly = t.GetMembers()
                    .OfType<IPropertySymbol>()
                    .All(property => property.IsReadOnly || property.SetMethod?.IsInitOnly == true);

                return allFieldsReadonly && allPropertiesReadonly;
            }
        }

        public static bool IsStateless(INamedTypeSymbol namedTypeSymbol)
        {
            ArgumentNullException.ThrowIfNull(namedTypeSymbol);

            // Check if there are any instance fields
            var hasInstanceFields = namedTypeSymbol
                .GetMembers()
                .OfType<IFieldSymbol>()
                .Any(field => !field.IsStatic);

            // Check if there are any instance properties
            var hasInstanceProperties = namedTypeSymbol
                .GetMembers()
                .OfType<IPropertySymbol>()
                .Any(property => !property.IsStatic);

            // Check if there are any instance events
            var hasInstanceEvents = namedTypeSymbol
                .GetMembers()
                .OfType<IEventSymbol>()
                .Any(@event => !@event.IsStatic);

            return !hasInstanceFields && !hasInstanceProperties && !hasInstanceEvents;
        }

        public static bool IsStaticless(INamedTypeSymbol namedTypeSymbol)
        {
            ArgumentNullException.ThrowIfNull(namedTypeSymbol);

            return namedTypeSymbol.GetMembers().All(m => !m.IsStatic);
        }
    }
}
