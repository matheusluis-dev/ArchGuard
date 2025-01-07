namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using System.Linq;

    internal static partial class TypePredicate
    {
        internal static Func<Type, StringComparison, bool> AreOfType(params Type[] types)
        {
            return (type, _) => types.Contains(type);
        }

        internal static Func<Type, StringComparison, bool> ImplementInterface(
            params Type[] interfaces
        )
        {
            return (type, _) =>
                !interfaces.Contains(type)
                && interfaces.Any(@interface => @interface.IsAssignableFrom(type));
        }

        internal static Func<Type, StringComparison, bool> DoNotImplementInterface(
            params Type[] interfaces
        )
        {
            return (type, _) => interfaces.Any(@interface => !@interface.IsAssignableFrom(type));
        }

        internal static Func<Type, StringComparison, bool> Inherit(params Type[] types)
        {
            return (type, _) => types.Any(t => type.IsSubclassOf(t));
        }

        internal static Func<Type, StringComparison, bool> NotInherit(params Type[] typeParam)
        {
            return (type, _) => !Inherit(typeParam)(type, _);
        }

        internal static Func<Type, StringComparison, bool> Generic { get; } =
            (type, _) => type.IsGenericType;
        internal static Func<Type, StringComparison, bool> NotGeneric { get; } =
            (type, _) => !Generic(type, _);
    }
}
