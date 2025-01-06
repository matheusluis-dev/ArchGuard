namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using ArchGuard.Library.Extensions.Type;

    internal static partial class TypePredicate
    {
        internal static Func<Type, bool> Class { get; } = type => type.IsNonRecordClass();
        internal static Func<Type, bool> NotClass { get; } = type => !Class(type);

        internal static Func<Type, bool> Interface { get; } = type => type.IsInterface;
        internal static Func<Type, bool> NotInterface { get; } = type => !Interface(type);

        internal static Func<Type, bool> Struct { get; } = type => type.IsStruct();
        internal static Func<Type, bool> NotStruct { get; } = type => !Struct(type);

        internal static Func<Type, bool> Enum { get; } = type => type.IsEnum;
        internal static Func<Type, bool> NotEnum { get; } = type => !Enum(type);

#if NET5_0_OR_GREATER
        internal static Func<Type, bool> Record { get; } = type => type.IsRecord();
        internal static Func<Type, bool> NotRecord { get; } = type => !Record(type);
#endif
    }
}
