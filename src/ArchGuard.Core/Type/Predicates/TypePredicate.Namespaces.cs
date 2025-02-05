namespace ArchGuard.Core.Predicates.Type
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Core.Type.Models;
    using ArchGuard.Extensions;
    using Microsoft.CodeAnalysis;

    public static partial class TypePredicate
    {
        private static bool NamespaceDefaultPredicate(TypeDefinition type, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            return !(type.Symbol.ContainingNamespace is null)
                && !type.Symbol.ContainingNamespace.IsGlobalNamespace;
        }

        public static Func<TypeDefinition, StringComparison, bool> ResideInNamespace(
            IEnumerable<string> names
        )
        {
            return (type, comparison) =>
            {
                var namespaceExists = names.Contains(
                    type.Symbol.ContainingNamespace.GetFullName(),
                    comparison.ToComparer()
                );

                return names.Any(name =>
                {
                    var @namespace =
                        namespaceExists || name[name.Length - 1] == '.' ? name : name + ".";

                    return NamespaceDefaultPredicate(type, name)
                        && type.Symbol.ContainingNamespace.GetFullName()
                            .StartsWith(@namespace, comparison);
                });
            };
        }

        public static Func<TypeDefinition, StringComparison, bool> DoNotResideInNamespace(
            IEnumerable<string> name
        )
        {
            return (type, comparison) => !ResideInNamespace(name)(type, comparison);
        }

        public static Func<TypeDefinition, StringComparison, bool> ResideInNamespaceContaining(
            IEnumerable<string> names
        )
        {
            return (type, comparison) =>
                names.Any(name =>
                    NamespaceDefaultPredicate(type, name)
                    && type.Symbol.ContainingNamespace.GetFullName().IndexOf(name, comparison) != -1
                );
        }

        public static Func<TypeDefinition, StringComparison, bool> DoNotResideInNamespaceContaining(
            IEnumerable<string> name
        )
        {
            return (type, comparison) => !ResideInNamespaceContaining(name)(type, comparison);
        }

        public static Func<TypeDefinition, StringComparison, bool> ResideInNamespaceEndingWith(
            IEnumerable<string> names
        )
        {
            return (type, comparison) =>
                names.Any(name =>
                    NamespaceDefaultPredicate(type, name)
                    && type.Symbol.ContainingNamespace.GetFullName().EndsWith(name, comparison)
                );
        }

        public static Func<TypeDefinition, StringComparison, bool> DoNotResideInNamespaceEndingWith(
            IEnumerable<string> name
        )
        {
            return (type, comparison) => !ResideInNamespaceEndingWith(name)(type, comparison);
        }
    }
}
