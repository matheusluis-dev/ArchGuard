namespace ArchGuardType.Predicates
{
    using System;
    using Microsoft.CodeAnalysis;

    internal static partial class TypeDefinitionPredicate
    {
        internal static Func<TypeDefinition, StringComparison, bool> Class =>
            (type, _) => type.Symbol.TypeKind == TypeKind.Class && NotRecord(type, _);
        internal static Func<TypeDefinition, StringComparison, bool> NotClass =>
            (type, _) => type.Symbol.TypeKind is not TypeKind.Class || type.Symbol.IsRecord;

        internal static Func<TypeDefinition, StringComparison, bool> Interface =>
            (type, _) => type.Symbol.TypeKind == TypeKind.Interface;
        internal static Func<TypeDefinition, StringComparison, bool> NotInterface =>
            (type, _) => !Interface(type, _);

        internal static Func<TypeDefinition, StringComparison, bool> Struct =>
            (type, _) => type.Symbol.TypeKind == TypeKind.Struct;
        internal static Func<TypeDefinition, StringComparison, bool> NotStruct =>
            (type, _) => !Struct(type, _);

        internal static Func<TypeDefinition, StringComparison, bool> Enum =>
            (type, _) => type.Symbol.TypeKind == TypeKind.Enum;
        internal static Func<TypeDefinition, StringComparison, bool> NotEnum =>
            (type, _) => !Enum(type, _);

        internal static Func<TypeDefinition, StringComparison, bool> Record =>
            (type, _) => type.Symbol.IsRecord && type.Symbol.TypeKind is not TypeKind.Struct;
        internal static Func<TypeDefinition, StringComparison, bool> NotRecord =>
            (type, _) => !type.Symbol.IsRecord || type.Symbol.TypeKind is TypeKind.Struct;
    }
}
