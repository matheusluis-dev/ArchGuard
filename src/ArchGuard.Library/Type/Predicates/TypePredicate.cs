namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using System.Linq;
    using ArchGuard.Library.Extensions;
    using Microsoft.CodeAnalysis;

    internal static partial class TypePredicate
    {
        public static Func<INamedTypeSymbol, StringComparison, bool> ImplementInterface(
            Type[] types
        )
        {
            return (type, _) =>
                // Interfaces do not implement each other, they inherit
                type.TypeKind != TypeKind.Interface
                && type.AllInterfaces.Any(@interface =>
                    types
                        .Select(t => t.GetFullName())
                        .Contains(@interface.GetFullName(), StringComparer.CurrentCulture)
                );
        }

        public static Func<INamedTypeSymbol, StringComparison, bool> NotImplementInterface(
            Type[] types
        )
        {
            return (type, _) => !ImplementInterface(types)(type, _);
        }

        public static Func<INamedTypeSymbol, StringComparison, bool> Inherit(Type[] types)
        {
            return (type, _) => type.Inherit(types);
        }

        public static Func<INamedTypeSymbol, StringComparison, bool> NotInherit(Type[] types)
        {
            return (type, _) => !Inherit(types)(type, _);
        }

        public static Func<INamedTypeSymbol, StringComparison, bool> Generic =>
            (type, _) => type.IsGenericType;

        public static Func<INamedTypeSymbol, StringComparison, bool> NotGeneric =>
            (type, _) => !Generic(type, _);

        public static Func<INamedTypeSymbol, StringComparison, bool> Immutable =>
            (type, _) => type.IsImmutable();

        public static Func<INamedTypeSymbol, StringComparison, bool> Mutable =>
            (type, _) => !Immutable(type, _);
    }
}
