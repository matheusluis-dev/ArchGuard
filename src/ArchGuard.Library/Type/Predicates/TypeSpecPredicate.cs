namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using System.Linq;

    internal static partial class TypeSpecPredicate
    {
        internal static Func<TypeSpecRoslyn, StringComparison, bool> AreOfType(Type[] types)
        {
            return (type, _) => false;
            //return (type, _) => types.Contains(type.ReflectionType);
        }

        // TODO: refactor fullnames
        internal static Func<TypeSpecRoslyn, StringComparison, bool> ImplementInterface(
            Type[] interfaces
        )
        {
            return (type, _) =>
                !interfaces.Any(i =>
                    type.Name.Equals(i.Name, StringComparison.Ordinal)
                    && interfaces.Any(j =>
                        type.InterfacesImplemented.Contains(j.FullName, StringComparer.Ordinal)
                    )
                );
        }

        internal static Func<TypeSpecRoslyn, StringComparison, bool> DoNotImplementInterface(
            Type[] interfaces
        )
        {
            return (type, _) =>
                interfaces.Any(i =>
                    type.InterfacesImplemented.Contains(i.FullName, StringComparer.Ordinal)
                );
        }

        internal static Func<TypeSpecRoslyn, StringComparison, bool> Inherit(Type[] types)
        {
            return (type, _) => false;
            //return (type, _) => types.Any(t => type.ReflectionType.IsSubclassOf(t));
        }

        internal static Func<TypeSpecRoslyn, StringComparison, bool> NotInherit(Type[] typeParam)
        {
            return (type, _) => !Inherit(typeParam)(type, _);
        }

        internal static Func<TypeSpecRoslyn, StringComparison, bool> Generic =>
            (type, _) => type.IsGeneric;

        internal static Func<TypeSpecRoslyn, StringComparison, bool> NotGeneric =>
            (type, _) => !Generic(type, _);
    }
}
