namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using System.Linq;
    using ArchGuard.Library.Extensions;
    using Microsoft.CodeAnalysis;

    internal static partial class TypePredicate
    {
        public static Func<Type_, StringComparison, bool> ImplementInterface(Type[] types)
        {
            return (type, _) =>
                // Interfaces do not implement each other, they inherit
                type.Symbol.TypeKind != TypeKind.Interface
                && type.Symbol.AllInterfaces.Any(@interface =>
                    types
                        .Select(t => t.GetFullName())
                        .Contains(@interface.GetFullName(), StringComparer.CurrentCulture)
                );
        }

        public static Func<Type_, StringComparison, bool> NotImplementInterface(Type[] types)
        {
            return (type, _) => !ImplementInterface(types)(type, _);
        }

        public static Func<Type_, StringComparison, bool> Inherit(Type[] types)
        {
            return (type, _) => type.Symbol.Inherit(types);
        }

        public static Func<Type_, StringComparison, bool> NotInherit(Type[] types)
        {
            return (type, _) => !Inherit(types)(type, _);
        }

        public static Func<Type_, StringComparison, bool> Generic =>
            (type, _) => type.Symbol.IsGenericType;

        public static Func<Type_, StringComparison, bool> NotGeneric =>
            (type, _) => !Generic(type, _);

        public static Func<Type_, StringComparison, bool> Immutable =>
            (type, _) => type.Symbol.IsImmutable();

        public static Func<Type_, StringComparison, bool> Mutable =>
            (type, _) => !Immutable(type, _);

        public static Func<Type_, StringComparison, bool> Stateless =>
            (type, _) => type.Symbol.IsStateless();

        public static Func<Type_, StringComparison, bool> NotStateless =>
            (type, _) => !Stateless(type, _);

        public static Func<Type_, StringComparison, bool> Staticless =>
            (type, _) => type.Symbol.IsStaticless();

        public static Func<Type_, StringComparison, bool> NotStaticless =>
            (type, _) => !Staticless(type, _);

        public static Func<Type_, StringComparison, bool> ExternallyImmutable =>
            (type, _) => type.IsExternallyImmutable();

        public static Func<Type_, StringComparison, bool> ExternallyMutable =>
            (type, _) => !ExternallyImmutable(type, _);
    }
}
