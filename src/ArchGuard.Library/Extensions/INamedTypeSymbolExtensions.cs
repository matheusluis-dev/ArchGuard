namespace ArchGuard.Library.Extensions
{
    using System;
    using System.Collections.Generic;
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
            if (iNamedTypeSymbol.TypeKind == TypeKind.Interface)
            {
                return iNamedTypeSymbol.AllInterfaces.Any(i =>
                    types.Any(t =>
                        t.GetFullName().Contains(i.GetFullName(), StringComparison.Ordinal)
                    )
                );
            }

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

        public static bool IsImmutable(this INamedTypeSymbol iNamedTypeSymbol)
        {
            var list = new List<INamedTypeSymbol> { iNamedTypeSymbol };

            var baseType = iNamedTypeSymbol.BaseType;
            while (baseType is not null)
            {
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
                    .All(property => property.IsReadOnly || property.SetMethod.IsInitOnly);

                return allFieldsReadonly && allPropertiesReadonly;
            }
        }

        public static bool IsStateless(this INamedTypeSymbol iNamedTypeSymbol)
        {
            // Check if there are any instance fields
            var hasInstanceFields = iNamedTypeSymbol
                .GetMembers()
                .OfType<IFieldSymbol>()
                .Any(field => !field.IsStatic);

            // Check if there are any instance properties
            var hasInstanceProperties = iNamedTypeSymbol
                .GetMembers()
                .OfType<IPropertySymbol>()
                .Any(property => !property.IsStatic);

            // Check if there are any instance events
            var hasInstanceEvents = iNamedTypeSymbol
                .GetMembers()
                .OfType<IEventSymbol>()
                .Any(@event => !@event.IsStatic);

            return !hasInstanceFields && !hasInstanceProperties && !hasInstanceEvents;
        }

        public static bool IsStaticless(this INamedTypeSymbol iNamedTypeSymbol)
        {
            // Check if there are any static fields
            var hasStaticFields = iNamedTypeSymbol
                .GetMembers()
                .OfType<IFieldSymbol>()
                .Any(field => field.IsStatic);

            // Check if there are any static properties
            var hasStaticProperties = iNamedTypeSymbol
                .GetMembers()
                .OfType<IPropertySymbol>()
                .Any(property => property.IsStatic);

            // Check if there are any static methods
            var hasStaticMethods = iNamedTypeSymbol
                .GetMembers()
                .OfType<IMethodSymbol>()
                .Any(method => method.IsStatic);

            // Check if there are any static events
            var hasStaticEvents = iNamedTypeSymbol
                .GetMembers()
                .OfType<IEventSymbol>()
                .Any(@event => @event.IsStatic);

            return !hasStaticFields
                && !hasStaticProperties
                && !hasStaticMethods
                && !hasStaticEvents;
        }
    }
}
