namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using ArchGuard.Library.Extensions.Type;

    internal static partial class TypePredicate
    {
        internal static Func<Type, StringComparison, bool> Class =>
            (type, comparison) => type.IsNonRecordClass(comparison);
        internal static Func<Type, StringComparison, bool> NotClass =>
            (type, comparison) => !Class(type, comparison);

        internal static Func<Type, StringComparison, bool> Interface =>
            (type, _) => type.IsInterface;
        internal static Func<Type, StringComparison, bool> NotInterface =>
            (type, _) => !Interface(type, _);

        internal static Func<Type, StringComparison, bool> Struct => (type, _) => type.IsStruct();
        internal static Func<Type, StringComparison, bool> NotStruct =>
            (type, _) => !Struct(type, _);

        internal static Func<Type, StringComparison, bool> Enum => (type, _) => type.IsEnum;
        internal static Func<Type, StringComparison, bool> NotEnum => (type, _) => !Enum(type, _);

#if NET5_0_OR_GREATER
        internal static Func<Type, StringComparison, bool> Record =>
            (type, comparison) => type.IsRecord(comparison);
        internal static Func<Type, StringComparison, bool> NotRecord =>
            (type, comparison) => !Record(type, comparison);
#endif
    }
}
