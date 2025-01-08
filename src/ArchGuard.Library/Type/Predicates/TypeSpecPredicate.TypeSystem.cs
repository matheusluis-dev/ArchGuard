namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using ArchGuard.Library.Extensions.Type;

    internal static partial class TypeSpecPredicate
    {
        internal static Func<TypeSpec, StringComparison, bool> Class => (type, _) => type.IsClass;
        internal static Func<TypeSpec, StringComparison, bool> NotClass =>
            (type, comparison) => !Class(type, comparison);

        internal static Func<TypeSpec, StringComparison, bool> Interface =>
            (type, _) => type.ReflectionType.IsInterface;
        internal static Func<TypeSpec, StringComparison, bool> NotInterface =>
            (type, _) => !Interface(type, _);

        internal static Func<TypeSpec, StringComparison, bool> Struct =>
            (type, _) => type.ReflectionType.IsStruct();
        internal static Func<TypeSpec, StringComparison, bool> NotStruct =>
            (type, _) => !Struct(type, _);

        internal static Func<TypeSpec, StringComparison, bool> Enum =>
            (type, _) => type.ReflectionType.IsEnum;
        internal static Func<TypeSpec, StringComparison, bool> NotEnum =>
            (type, _) => !Enum(type, _);

#if NET5_0_OR_GREATER
        internal static Func<TypeSpec, StringComparison, bool> Record => (type, _) => type.IsRecord;
        internal static Func<TypeSpec, StringComparison, bool> NotRecord =>
            (type, _) => !Record(type, _);
#endif
    }
}
