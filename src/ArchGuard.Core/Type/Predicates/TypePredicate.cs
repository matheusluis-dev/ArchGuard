namespace ArchGuard.Core.Predicates.Type
{
    using System;
    using System.Linq;
    using ArchGuard.Core.Extensions;
    using ArchGuard.Core.Type.Models;
    using ArchGuard.Extensions;
    using Microsoft.CodeAnalysis;

    public static partial class TypePredicate
    {
        public static Func<TypeDefinition, StringComparison, bool> ImplementInterface(Type[] types)
        {
            return (type, _) =>
                type.GetImplementedInterfaces()
                    .Any(@interface =>
                        types
                            .Select(t => t.GetFullNameClean())
                            .Contains(@interface.FullName, StringComparer.Ordinal)
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
            return (type, _) =>
                type.GetInheritances()
                    .Any(type =>
                        types
                            .Select(type => type.GetFullNameClean())
                            .Contains(type.FullName, StringComparer.Ordinal)
                    );
        }

        public static Func<TypeDefinition, StringComparison, bool> NotInherit(Type[] types)
        {
            return (type, _) => !Inherit(types)(type, _);
        }

        public static Func<TypeDefinition, StringComparison, bool> Generic =>
            (type, _) => type.IsGenericType;

        public static Func<TypeDefinition, StringComparison, bool> NotGeneric =>
            (type, _) => !Generic(type, _);

        public static Func<TypeDefinition, StringComparison, bool> Immutable =>
            (type, _) => type.IsImmutable;

        public static Func<TypeDefinition, StringComparison, bool> Mutable =>
            (type, _) => !Immutable(type, _);

        public static Func<TypeDefinition, StringComparison, bool> Stateless =>
            (type, _) => type.IsStateless;

        public static Func<TypeDefinition, StringComparison, bool> NotStateless =>
            (type, _) => !Stateless(type, _);

        public static Func<TypeDefinition, StringComparison, bool> Staticless =>
            (type, _) => type.IsStaticless;

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
                        types.Contains(dependency.FullName, comparison.ToComparer())
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
                var dependenciesNamespaces = type.GetDependencies()
                    .Select(type => type.Namespace)
                    // a type can't depend on its own namespace
                    .Where(@namespace => !type.Namespace.StartsWith(@namespace, comparison));

                return namespaces.Intersect(dependenciesNamespaces, comparison.ToComparer()).Any();
            };
        }

        public static Func<TypeDefinition, StringComparison, bool> NotHaveDependencyOnNamespace(
            string[] namespaces
        )
        {
            return (type, comparison) => !HaveDependencyOnNamespace(namespaces)(type, comparison);
        }

        public static Func<TypeDefinition, StringComparison, bool> HaveDependencyOnlyOnNamespace(
            string[] namespaces
        )
        {
            return (type, comparison) =>
            {
                var dependenciesNamespaces = type.GetDependencies()
                    .Select(type => type.Namespace)
                    // a type can't depend on its own namespace
                    .Where(@namespace => !@namespace.StartsWith(type.Namespace, comparison))
                    .ToList();

                var intersect = namespaces
                    .Intersect(dependenciesNamespaces, comparison.ToComparer())
                    .ToList();

                return dependenciesNamespaces.Count == intersect.Count;
            };
        }

        public static Func<TypeDefinition, StringComparison, bool> HaveParameterlessConstructor =>
            (type, _) => type.GetConstructors().Any(constructor => !constructor.HasParameters);

        public static Func<
            TypeDefinition,
            StringComparison,
            bool
        > NotHaveParameterlessConstructor => (type, _) => !HaveParameterlessConstructor(type, _);

        public static Func<TypeDefinition, StringComparison, bool> UsedBy(string[] types)
        {
            return (type, _) =>
                type.UsedBy().Any(type => types.Contains(type.FullName, StringComparer.Ordinal));
        }

        public static Func<TypeDefinition, StringComparison, bool> NotUsedBy(string[] types)
        {
            return (type, _) => !UsedBy(types)(type, _);
        }

        public static Func<
            TypeDefinition,
            StringComparison,
            bool
        > HaveSourceFilePathMatchingNamespace =>
            (type, comparison) => type.SourceFilePathMatchesNamespace(comparison);

        public static Func<
            TypeDefinition,
            StringComparison,
            bool
        > HaveSourceFileNameMatchingTypeName =>
            (type, comparison) => type.SourceFileNameMatchesTypeName(comparison);
    }
}
