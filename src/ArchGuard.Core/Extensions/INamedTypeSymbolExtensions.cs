namespace ArchGuard.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Core.Helpers;
    using Microsoft.CodeAnalysis;

    public static class INamedTypeSymbolExtensions
    {
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
                        field.IsReadOnly
                        || field.IsConst
                        || SymbolHelper.IsPrivateOrProtected(field)
                    );

                var allPropertiesReadonlyOrPrivate = t.GetMembers()
                    .OfType<IPropertySymbol>()
                    .All(property =>
                        property.IsReadOnly
                        || property.SetMethod?.IsInitOnly == true
                        || SymbolHelper.IsPrivateOrProtected(property)
                    );

                return allFieldsReadonlyOrPrivate && allPropertiesReadonlyOrPrivate;
            }
        }

        public static bool IsStaticless(this INamedTypeSymbol namedTypeSymbol)
        {
            ArgumentNullException.ThrowIfNull(namedTypeSymbol);

            return namedTypeSymbol.GetMembers().All(m => !m.IsStatic);
        }
    }
}
