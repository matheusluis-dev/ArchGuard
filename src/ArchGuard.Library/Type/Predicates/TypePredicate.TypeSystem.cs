namespace ArchGuard.Library
{
    using System;
    using Microsoft.CodeAnalysis;

    internal static partial class TypePredicate
    {
        internal static Func<INamedTypeSymbol, StringComparison, bool> Class =>
            (type, _) => type.TypeKind == TypeKind.Class && NotRecord(type, _);
        internal static Func<INamedTypeSymbol, StringComparison, bool> NotClass =>
            (type, comparison) => !Class(type, comparison);

        internal static Func<INamedTypeSymbol, StringComparison, bool> Interface =>
            (type, _) => type.TypeKind == TypeKind.Interface;
        internal static Func<INamedTypeSymbol, StringComparison, bool> NotInterface =>
            (type, _) => !Interface(type, _);

        internal static Func<INamedTypeSymbol, StringComparison, bool> Struct =>
            (type, _) => type.TypeKind == TypeKind.Struct;
        internal static Func<INamedTypeSymbol, StringComparison, bool> NotStruct =>
            (type, _) => !Struct(type, _);

        internal static Func<INamedTypeSymbol, StringComparison, bool> Enum =>
            (type, _) => type.TypeKind == TypeKind.Enum;
        internal static Func<INamedTypeSymbol, StringComparison, bool> NotEnum =>
            (type, _) => !Enum(type, _);

        internal static Func<INamedTypeSymbol, StringComparison, bool> Record =>
            (type, _) => type.IsRecord;
        internal static Func<INamedTypeSymbol, StringComparison, bool> NotRecord =>
            (type, _) => !Record(type, _);
    }
}
