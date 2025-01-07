namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using System.Linq;
    using ArchGuard.Library.Extensions;

    internal static partial class TypePredicate
    {
        private static bool NamespaceDefaultPredicate(Type type, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            return !(type.Namespace is null);
        }

        internal static Func<Type, StringComparison, bool> ResideInNamespace(params string[] names)
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

        internal static Func<Type, StringComparison, bool> DoNotResideInNamespace(
            params string[] name
        )
        {
            return (type, comparison) => !ResideInNamespace(name)(type, comparison);
        }

        internal static Func<Type, StringComparison, bool> ResideInNamespaceContaining(
            params string[] names
        )
        {
            return (type, comparison) =>
                names.Any(name =>
                    NamespaceDefaultPredicate(type, name)
                    && type.Namespace.IndexOf(name, comparison) != -1
                );
        }

        internal static Func<Type, StringComparison, bool> DoNotResideInNamespaceContaining(
            params string[] name
        )
        {
            return (type, comparison) => !ResideInNamespaceContaining(name)(type, comparison);
        }

        internal static Func<Type, StringComparison, bool> ResideInNamespaceEndingWith(
            params string[] names
        )
        {
            return (type, comparison) =>
                names.Any(name =>
                    NamespaceDefaultPredicate(type, name)
                    && type.Namespace.EndsWith(name, comparison)
                );
        }

        internal static Func<Type, StringComparison, bool> DoNotResideInNamespaceEndingWith(
            params string[] name
        )
        {
            return (type, comparison) => !ResideInNamespaceEndingWith(name)(type, comparison);
        }
    }
}
