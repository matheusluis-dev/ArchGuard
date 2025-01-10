namespace ArchGuard.Roslyn
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Roslyn.Extensions;
    using Microsoft.CodeAnalysis;

    internal static partial class TypePredicate
    {
        private static bool NamespaceDefaultPredicate(INamedTypeSymbol typeSpec, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            return !(typeSpec.ContainingNamespace is null)
                && !typeSpec.ContainingNamespace.IsGlobalNamespace;
        }

        internal static Func<INamedTypeSymbol, StringComparison, bool> ResideInNamespace(
            IEnumerable<string> names
        )
        {
            return (type, comparison) =>
            {
                var namespaceExists = names.Contains(
                    type.ContainingNamespace.Name,
                    comparison.ToComparer()
                );

                return names.Any(name =>
                {
                    var @namespace =
                        namespaceExists || name[name.Length - 1] == '.' ? name : name + ".";

                    return NamespaceDefaultPredicate(type, name)
                        && type.ContainingNamespace.Name.StartsWith(@namespace, comparison);
                });
            };
        }

        internal static Func<INamedTypeSymbol, StringComparison, bool> DoNotResideInNamespace(
            IEnumerable<string> name
        )
        {
            return (type, comparison) => !ResideInNamespace(name)(type, comparison);
        }

        internal static Func<INamedTypeSymbol, StringComparison, bool> ResideInNamespaceContaining(
            IEnumerable<string> names
        )
        {
            return (type, comparison) =>
                names.Any(name =>
                    NamespaceDefaultPredicate(type, name)
                    && type.ContainingNamespace.Name.IndexOf(name, comparison) != -1
                );
        }

        internal static Func<
            INamedTypeSymbol,
            StringComparison,
            bool
        > DoNotResideInNamespaceContaining(IEnumerable<string> name)
        {
            return (type, comparison) => !ResideInNamespaceContaining(name)(type, comparison);
        }

        internal static Func<INamedTypeSymbol, StringComparison, bool> ResideInNamespaceEndingWith(
            IEnumerable<string> names
        )
        {
            return (type, comparison) =>
                names.Any(name =>
                    NamespaceDefaultPredicate(type, name)
                    && type.ContainingNamespace.Name.EndsWith(name, comparison)
                );
        }

        internal static Func<
            INamedTypeSymbol,
            StringComparison,
            bool
        > DoNotResideInNamespaceEndingWith(IEnumerable<string> name)
        {
            return (type, comparison) => !ResideInNamespaceEndingWith(name)(type, comparison);
        }
    }
}
