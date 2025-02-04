namespace ArchGuard.Core.Predicates.Type
{
    using System;
    using Microsoft.CodeAnalysis;

    public static partial class TypePredicate
    {
        public static Func<TypeDefinition, StringComparison, bool> Class =>
            (type, _) => type.Symbol.TypeKind == TypeKind.Class && NotRecord(type, _);
        public static Func<TypeDefinition, StringComparison, bool> NotClass =>
            (type, _) => type.Symbol.TypeKind is not TypeKind.Class || type.Symbol.IsRecord;

        public static Func<TypeDefinition, StringComparison, bool> Interface =>
            (type, _) => type.Symbol.TypeKind == TypeKind.Interface;
        public static Func<TypeDefinition, StringComparison, bool> NotInterface =>
            (type, _) => !Interface(type, _);

        public static Func<TypeDefinition, StringComparison, bool> Struct =>
            (type, _) => type.Symbol.TypeKind == TypeKind.Struct && !type.Symbol.IsRecord;
        public static Func<TypeDefinition, StringComparison, bool> NotStruct =>
            (type, _) => type.Symbol.TypeKind is not TypeKind.Struct || type.Symbol.IsRecord;

        public static Func<TypeDefinition, StringComparison, bool> Enum =>
            (type, _) => type.Symbol.TypeKind == TypeKind.Enum;
        public static Func<TypeDefinition, StringComparison, bool> NotEnum =>
            (type, _) => !Enum(type, _);

        public static Func<TypeDefinition, StringComparison, bool> Record =>
            (type, _) => type.Symbol.IsRecord && type.Symbol.TypeKind is not TypeKind.Struct;
        public static Func<TypeDefinition, StringComparison, bool> NotRecord =>
            (type, _) => !type.Symbol.IsRecord || type.Symbol.TypeKind is TypeKind.Struct;

        public static Func<TypeDefinition, StringComparison, bool> RecordStruct =>
            (type, _) => type.Symbol.IsRecord && type.Symbol.TypeKind is TypeKind.Struct;
        public static Func<TypeDefinition, StringComparison, bool> NotRecordStruct =>
            (type, _) => !type.Symbol.IsRecord || type.Symbol.TypeKind is not TypeKind.Struct;
    }
}
