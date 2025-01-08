namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using System.Linq;

    internal static partial class TypeSpecPredicate
    {
        internal static Func<TypeSpec, StringComparison, bool> AreOfType(Type[] types)
        {
            return (type, _) => types.Contains(type.ReflectionType);
        }

        internal static Func<TypeSpec, StringComparison, bool> ImplementInterface(Type[] interfaces)
        {
            return (type, _) =>
                !interfaces.Contains(type.ReflectionType)
                && interfaces.Any(@interface => @interface.IsAssignableFrom(type.ReflectionType));
        }

        internal static Func<TypeSpec, StringComparison, bool> DoNotImplementInterface(
            Type[] interfaces
        )
        {
            return (type, _) =>
                interfaces.Any(@interface => !@interface.IsAssignableFrom(type.ReflectionType));
        }

        internal static Func<TypeSpec, StringComparison, bool> Inherit(Type[] types)
        {
            return (type, _) => types.Any(t => type.ReflectionType.IsSubclassOf(t));
        }

        internal static Func<TypeSpec, StringComparison, bool> NotInherit(Type[] typeParam)
        {
            return (type, _) => !Inherit(typeParam)(type, _);
        }

        internal static Func<TypeSpec, StringComparison, bool> Generic =>
            (type, _) => type.ReflectionType.IsGenericType;

        internal static Func<TypeSpec, StringComparison, bool> NotGeneric =>
            (type, _) => !Generic(type, _);
    }
}
