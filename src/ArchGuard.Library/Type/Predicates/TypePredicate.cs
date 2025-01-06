namespace ArchGuard.Library.Type.Predicates
{
    using System;

    internal static partial class TypePredicate
    {
        internal static Func<Type, bool> AreOfType(Type typeParam)
        {
            return type => type == typeParam;
        }

        internal static Func<Type, bool> ImplementInterface(Type @interface)
        {
            return type => type != @interface && @interface.IsAssignableFrom(type);
        }

        internal static Func<Type, bool> DoNotImplementInterface(Type @interface)
        {
            return type => !@interface.IsAssignableFrom(type);
        }

        internal static Func<Type, bool> Inherit(Type typeParam)
        {
            return type => type.IsSubclassOf(typeParam);
        }

        internal static Func<Type, bool> NotInherit(Type typeParam)
        {
            return type => !Inherit(typeParam)(type);
        }

        internal static Func<Type, bool> Generic { get; } = type => type.IsGenericType;
        internal static Func<Type, bool> NotGeneric { get; } = type => !Generic(type);
    }
}
