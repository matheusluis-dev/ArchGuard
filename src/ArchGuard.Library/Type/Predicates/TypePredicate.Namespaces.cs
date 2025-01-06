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

        internal static Func<Type, bool> ResideInNamespace(string name, StringComparison comparison)
        {
            return type =>
            {
                var namespaceExists = type.Namespace.Equals(name, comparison);
                var @namespace =
                    namespaceExists || name[name.Length - 1] == '.' ? name : name + ".";

                return NamespaceDefaultPredicate(type, name)
                    && type.Namespace.StartsWith(@namespace, comparison);
            };
        }

        internal static Func<Type, bool> DoNotResideInNamespace(
            string name,
            StringComparison comparison
        )
        {
            return type => !ResideInNamespace(name, comparison)(type);
        }

        internal static Func<Type, bool> ResideInNamespaceContaining(
            string name,
            StringComparison comparison
        )
        {
            return type =>
                NamespaceDefaultPredicate(type, name)
                && type.Namespace.IndexOf(name, comparison) >= 0;
        }

        internal static Func<Type, bool> DoNotResideInNamespaceContaining(
            string name,
            StringComparison comparison
        )
        {
            return type => !ResideInNamespaceContaining(name, comparison)(type);
        }

        internal static Func<Type, bool> ResideInNamespaceEndingWith(
            string name,
            StringComparison comparison
        )
        {
            return type =>
                NamespaceDefaultPredicate(type, name) && type.Namespace.EndsWith(name, comparison);
        }

        internal static Func<Type, bool> DoNotResideInNamespaceEndingWith(
            string name,
            StringComparison comparison
        )
        {
            return type => !ResideInNamespaceEndingWith(name, comparison)(type);
        }
    }
}
