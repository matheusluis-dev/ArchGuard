namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using Microsoft.CodeAnalysis;

    internal static partial class TypePredicate
    {
        internal static Func<Type_, StringComparison, bool> Class =>
            (type, _) => type.Symbol.TypeKind == TypeKind.Class && NotRecord(type, _);
        internal static Func<Type_, StringComparison, bool> NotClass =>
            (type, comparison) => !Class(type, comparison);

        internal static Func<Type_, StringComparison, bool> Interface =>
            (type, _) => type.Symbol.TypeKind == TypeKind.Interface;
        internal static Func<Type_, StringComparison, bool> NotInterface =>
            (type, _) => !Interface(type, _);

        internal static Func<Type_, StringComparison, bool> Struct =>
            (type, _) => type.Symbol.TypeKind == TypeKind.Struct;
        internal static Func<Type_, StringComparison, bool> NotStruct =>
            (type, _) => !Struct(type, _);

        internal static Func<Type_, StringComparison, bool> Enum =>
            (type, _) => type.Symbol.TypeKind == TypeKind.Enum;
        internal static Func<Type_, StringComparison, bool> NotEnum => (type, _) => !Enum(type, _);

        internal static Func<Type_, StringComparison, bool> Record =>
            (type, _) => type.Symbol.IsRecord;
        internal static Func<Type_, StringComparison, bool> NotRecord =>
            (type, _) => !Record(type, _);
    }
}
