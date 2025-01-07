namespace ArchGuard.Library.Type.Predicates
{
    using System;

    internal static partial class TypePredicate
    {
        private static bool NamespaceDefaultPredicate(Type type, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            return !(type.Namespace is null);
        }

        internal static Func<Type, StringComparison, bool> ResideInNamespace(string name)
        {
            return (type, comparison) =>
            {
                var namespaceExists = type.Namespace.Equals(name, comparison);
                var @namespace =
                    namespaceExists || name[name.Length - 1] == '.' ? name : name + ".";

                return NamespaceDefaultPredicate(type, name)
                    && type.Namespace.StartsWith(@namespace, comparison);
            };
        }

        internal static Func<Type, StringComparison, bool> DoNotResideInNamespace(string name)
        {
            return (type, comparison) => !ResideInNamespace(name)(type, comparison);
        }

        internal static Func<Type, StringComparison, bool> ResideInNamespaceContaining(string name)
        {
            return (type, comparison) =>
                NamespaceDefaultPredicate(type, name)
                && type.Namespace.IndexOf(name, comparison) >= 0;
        }

        internal static Func<Type, StringComparison, bool> DoNotResideInNamespaceContaining(
            string name
        )
        {
            return (type, comparison) => !ResideInNamespaceContaining(name)(type, comparison);
        }

        internal static Func<Type, StringComparison, bool> ResideInNamespaceEndingWith(string name)
        {
            return (type, comparison) =>
                NamespaceDefaultPredicate(type, name) && type.Namespace.EndsWith(name, comparison);
        }

        internal static Func<Type, StringComparison, bool> DoNotResideInNamespaceEndingWith(
            string name
        )
        {
            return (type, comparison) => !ResideInNamespaceEndingWith(name)(type, comparison);
        }
    }
}
