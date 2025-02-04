namespace ArchGuard.Core.Predicates.Type
{
    using System;
    using System.Linq;
    using ArchGuard.Extensions;
    using Microsoft.CodeAnalysis;

    public static partial class TypePredicate
    {
        public static Func<TypeDefinition, StringComparison, bool> ImplementInterface(Type[] types)
        {
            return (type, _) =>
                // Interfaces do not implement each other, they inherit
                type.Symbol.TypeKind != TypeKind.Interface
                && type.Symbol.AllInterfaces.Any(@interface =>
                    types
                        .Select(t => t.GetFullNameClean())
                        .Contains(@interface.GetFullName(), StringComparer.CurrentCulture)
                );
        }

        public static Func<TypeDefinition, StringComparison, bool> NotImplementInterface(
            Type[] types
        )
        {
            return (type, _) => !ImplementInterface(types)(type, _);
        }

        public static Func<TypeDefinition, StringComparison, bool> Inherit(Type[] types)
        {
            return (type, _) => type.Symbol.Inherit(types);
        }

        public static Func<TypeDefinition, StringComparison, bool> NotInherit(Type[] types)
        {
            return (type, _) => !Inherit(types)(type, _);
        }

        public static Func<TypeDefinition, StringComparison, bool> Generic =>
            (type, _) => type.Symbol.IsGenericType;

        public static Func<TypeDefinition, StringComparison, bool> NotGeneric =>
            (type, _) => !Generic(type, _);

        public static Func<TypeDefinition, StringComparison, bool> Immutable =>
            (type, _) => type.Symbol.IsImmutable();

        public static Func<TypeDefinition, StringComparison, bool> Mutable =>
            (type, _) => !Immutable(type, _);

        public static Func<TypeDefinition, StringComparison, bool> Stateless =>
            (type, _) => type.Symbol.IsStateless();

        public static Func<TypeDefinition, StringComparison, bool> NotStateless =>
            (type, _) => !Stateless(type, _);

        public static Func<TypeDefinition, StringComparison, bool> Staticless =>
            (type, _) => type.Symbol.IsStaticless();

        public static Func<TypeDefinition, StringComparison, bool> NotStaticless =>
            (type, _) => !Staticless(type, _);

        public static Func<TypeDefinition, StringComparison, bool> ExternallyImmutable =>
            (type, _) => type.IsExternallyImmutable();

        public static Func<TypeDefinition, StringComparison, bool> ExternallyMutable =>
            (type, _) => !ExternallyImmutable(type, _);

        public static Func<TypeDefinition, StringComparison, bool> HaveDependencyOn(string[] types)
        {
            return (type, comparison) =>
                type.GetDependencies()
                    .Any(dependency =>
                        types.Contains(dependency.Symbol.GetFullName(), comparison.ToComparer())
                    );
        }

        public static Func<TypeDefinition, StringComparison, bool> NotHaveDependencyOn(
            string[] types
        )
        {
            return (type, comparison) => !HaveDependencyOn(types)(type, comparison);
        }

        public static Func<TypeDefinition, StringComparison, bool> HaveDependencyOnNamespace(
            string[] namespaces
        )
        {
            return (type, comparison) =>
            {
                var typeNamespace = type.Symbol.ContainingNamespace.GetFullName();

                var dependenciesNamespaces = type.GetDependencies()
                    .Select(t => t.Symbol.ContainingNamespace.GetFullName())
                    // a type can't depend on its own namespace
                    .Where(@namespace => !typeNamespace.StartsWith(@namespace, comparison));

                return namespaces.Intersect(dependenciesNamespaces, comparison.ToComparer()).Any();
            };
        }

        public static Func<TypeDefinition, StringComparison, bool> NotHaveDependencyOnNamespace(
            string[] namespaces
        )
        {
            return (type, comparison) =>
            {
                var typeNamespace = type.Symbol.ContainingNamespace.GetFullName();

                var dependenciesNamespaces = type.GetDependencies()
                    .Select(t => t.Symbol.ContainingNamespace.GetFullName())
                    // a type can't depend on its own namespace
                    .Where(@namespace => !typeNamespace.StartsWith(@namespace, comparison));

                return !namespaces.Intersect(dependenciesNamespaces, comparison.ToComparer()).Any();
            };
        }

        public static Func<TypeDefinition, StringComparison, bool> HaveDependencyOnlyOnNamespace(
            string[] namespaces
        )
        {
            return (type, comparison) =>
            {
                var typeNamespace = type.Symbol.ContainingNamespace.GetFullName();

                var dependenciesNamespaces = type.GetDependencies()
                    .Select(t => t.Symbol.ContainingNamespace.GetFullName())
                    // a type can't depend on its own namespace
                    .Where(@namespace => !@namespace.StartsWith(typeNamespace, comparison))
                    .ToList();

                var intersect = namespaces
                    .Intersect(dependenciesNamespaces, comparison.ToComparer())
                    .ToList();

                return dependenciesNamespaces.Count == intersect.Count;
            };
        }

        public static Func<TypeDefinition, StringComparison, bool> HaveParameterlessConstructor =>
            (type, _) => type.Symbol.Constructors.Any(constructor => !constructor.Parameters.Any());

        public static Func<
            TypeDefinition,
            StringComparison,
            bool
        > NotHaveParameterlessConstructor => (type, _) => !HaveParameterlessConstructor(type, _);

        public static Func<TypeDefinition, StringComparison, bool> UsedBy(string[] types)
        {
            return (type, _) => type.IsUsedBy(types);
        }

        public static Func<TypeDefinition, StringComparison, bool> NotUsedBy(string[] types)
        {
            return (type, _) => !UsedBy(types)(type, _);
        }
    }
}
