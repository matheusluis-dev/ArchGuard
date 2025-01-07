namespace ArchGuard.Library.Type.Predicates
{
    using System;

    internal static partial class TypePredicate
    {
        internal static Func<Type, StringComparison, bool> AreOfType(Type typeParam)
        {
            return (type, _) => type == typeParam;
        }

        internal static Func<Type, StringComparison, bool> ImplementInterface(Type @interface)
        {
            return (type, _) => type != @interface && @interface.IsAssignableFrom(type);
        }

        internal static Func<Type, StringComparison, bool> DoNotImplementInterface(Type @interface)
        {
            return (type, _) => !@interface.IsAssignableFrom(type);
        }

        internal static Func<Type, StringComparison, bool> Inherit(Type typeParam)
        {
            return (type, _) => type.IsSubclassOf(typeParam);
        }

        internal static Func<Type, StringComparison, bool> NotInherit(Type typeParam)
        {
            return (type, _) => !Inherit(typeParam)(type, _);
        }

        internal static Func<Type, StringComparison, bool> Generic { get; } =
            (type, _) => type.IsGenericType;
        internal static Func<Type, StringComparison, bool> NotGeneric { get; } =
            (type, _) => !Generic(type, _);
    }
}
