namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using ArchGuard.Library.Extensions.Type;

    internal static partial class TypePredicate
    {
        internal static Func<Type, StringComparison, bool> Class { get; } =
            (type, comparison) => type.IsNonRecordClass(comparison);
        internal static Func<Type, StringComparison, bool> NotClass { get; } =
            (type, comparison) => !Class(type, comparison);

        internal static Func<Type, StringComparison, bool> Interface { get; } =
            (type, _) => type.IsInterface;
        internal static Func<Type, StringComparison, bool> NotInterface { get; } =
            (type, _) => !Interface(type, _);

        internal static Func<Type, StringComparison, bool> Struct { get; } =
            (type, _) => type.IsStruct();
        internal static Func<Type, StringComparison, bool> NotStruct { get; } =
            (type, _) => !Struct(type, _);

        internal static Func<Type, StringComparison, bool> Enum { get; } = (type, _) => type.IsEnum;
        internal static Func<Type, StringComparison, bool> NotEnum { get; } =
            (type, _) => !Enum(type, _);

#if NET5_0_OR_GREATER
        internal static Func<Type, StringComparison, bool> Record { get; } =
            (type, comparison) => type.IsRecord(comparison);
        internal static Func<Type, StringComparison, bool> NotRecord { get; } =
            (type, comparison) => !Record(type, comparison);
#endif
    }
}
