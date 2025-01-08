namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Library.Extensions;

    internal static partial class TypeSpecPredicate
    {
        private static bool NamespaceDefaultPredicate(TypeSpecRoslyn typeSpec, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            return !(typeSpec.Namespace is null);
        }

        internal static Func<TypeSpecRoslyn, StringComparison, bool> ResideInNamespace(
            IEnumerable<string> names
        )
        {
            return (type, comparison) =>
            {
                var namespaceExists = names.Contains(type.Namespace, comparison.ToComparer());

                return names.Any(name =>
                {
                    var @namespace =
                        namespaceExists || name[name.Length - 1] == '.' ? name : name + ".";

                    return NamespaceDefaultPredicate(type, name)
                        && type.Namespace.StartsWith(@namespace, comparison);
                });
            };
        }

        internal static Func<TypeSpecRoslyn, StringComparison, bool> DoNotResideInNamespace(
            IEnumerable<string> name
        )
        {
            return (type, comparison) => !ResideInNamespace(name)(type, comparison);
        }

        internal static Func<TypeSpecRoslyn, StringComparison, bool> ResideInNamespaceContaining(
            IEnumerable<string> names
        )
        {
            return (type, comparison) =>
                names.Any(name =>
                    NamespaceDefaultPredicate(type, name)
                    && type.Namespace.IndexOf(name, comparison) != -1
                );
        }

        internal static Func<
            TypeSpecRoslyn,
            StringComparison,
            bool
        > DoNotResideInNamespaceContaining(IEnumerable<string> name)
        {
            return (type, comparison) => !ResideInNamespaceContaining(name)(type, comparison);
        }

        internal static Func<TypeSpecRoslyn, StringComparison, bool> ResideInNamespaceEndingWith(
            IEnumerable<string> names
        )
        {
            return (type, comparison) =>
                names.Any(name =>
                    NamespaceDefaultPredicate(type, name)
                    && type.Namespace.EndsWith(name, comparison)
                );
        }

        internal static Func<
            TypeSpecRoslyn,
            StringComparison,
            bool
        > DoNotResideInNamespaceEndingWith(IEnumerable<string> name)
        {
            return (type, comparison) => !ResideInNamespaceEndingWith(name)(type, comparison);
        }
    }
}
