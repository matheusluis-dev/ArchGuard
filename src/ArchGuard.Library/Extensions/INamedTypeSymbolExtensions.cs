namespace ArchGuard.Library.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CodeAnalysis;

    public static class INamedTypeSymbolExtensions
    {
        public static string GetName(this INamedTypeSymbol namedTypeSymbol)
        {
            ArgumentNullException.ThrowIfNull(namedTypeSymbol);

            var name = namedTypeSymbol.Name;
            var containingType = namedTypeSymbol.ContainingType;

            while (containingType != null)
            {
                name = $"{containingType.Name}+{name}";
                containingType = containingType.ContainingType;
            }

            return name;
        }

        public static string GetFullName(this INamedTypeSymbol namedTypeSymbol)
        {
            ArgumentNullException.ThrowIfNull(namedTypeSymbol);

            var fullName = namedTypeSymbol.GetName();

            var containingNamespace = namedTypeSymbol.ContainingNamespace;
            if (!containingNamespace.IsGlobalNamespace)
                fullName = $"{containingNamespace}.{fullName}";

            return fullName;
        }

        public static bool Inherit(this INamedTypeSymbol namedTypeSymbol, params Type[] types)
        {
            ArgumentNullException.ThrowIfNull(namedTypeSymbol);

            if (namedTypeSymbol.TypeKind == TypeKind.Interface)
            {
                return namedTypeSymbol.AllInterfaces.Any(i =>
                    types.Any(t =>
                        t.GetFullName().Contains(i.GetFullName(), StringComparison.Ordinal)
                    )
                );
            }

            var baseType = namedTypeSymbol.BaseType;

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

        public static bool IsImmutable(this INamedTypeSymbol namedTypeSymbol)
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
                    .All(property =>
                        property.IsReadOnly || property?.SetMethod?.IsInitOnly == true
                    );

                return allFieldsReadonly && allPropertiesReadonly;
            }
        }

        public static bool IsImmutableExternally(this INamedTypeSymbol namedTypeSymbol)
        {
            ArgumentNullException.ThrowIfNull(namedTypeSymbol);

            var list = new List<INamedTypeSymbol> { namedTypeSymbol };

            var baseType = namedTypeSymbol.BaseType;
            while (baseType is not null)
            {
                list.Add(baseType);
                baseType = baseType.BaseType;
            }

            return list.All(IsImmutableExternally);

            static bool IsImmutableExternally(INamedTypeSymbol t)
            {
                var allFieldsReadonlyOrPrivate = t.GetMembers()
                    .OfType<IFieldSymbol>()
                    .All(field =>
                        field.IsReadOnly || field.IsConst || field.IsPrivateOrProtected()
                    );

                var allPropertiesReadonlyOrPrivate = t.GetMembers()
                    .OfType<IPropertySymbol>()
                    .All(property =>
                        property.IsReadOnly
                        || property.SetMethod?.IsInitOnly == true
                        || property.IsPrivateOrProtected()
                    );

                return allFieldsReadonlyOrPrivate && allPropertiesReadonlyOrPrivate;
            }
        }

        public static bool IsStateless(this INamedTypeSymbol namedTypeSymbol)
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

        public static bool IsStaticless(this INamedTypeSymbol namedTypeSymbol)
        {
            ArgumentNullException.ThrowIfNull(namedTypeSymbol);

            return namedTypeSymbol.GetMembers().All(m => !m.IsStatic);
        }
    }
}
