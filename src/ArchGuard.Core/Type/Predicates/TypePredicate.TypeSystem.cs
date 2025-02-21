namespace ArchGuard.Core.Predicates.Type
{
    using System;
    using ArchGuard.Core.Type.Models;

    public static partial class TypePredicate
    {
        public static Func<TypeDefinition, StringComparison, bool> Class => (type, _) => type.IsClass;
        public static Func<TypeDefinition, StringComparison, bool> NotClass => (type, _) => !Class(type, _);

        public static Func<TypeDefinition, StringComparison, bool> Interface => (type, _) => type.IsInterface;
        public static Func<TypeDefinition, StringComparison, bool> NotInterface => (type, _) => !Interface(type, _);

        public static Func<TypeDefinition, StringComparison, bool> Struct => (type, _) => type.IsStruct;
        public static Func<TypeDefinition, StringComparison, bool> NotStruct => (type, _) => !Struct(type, _);

        public static Func<TypeDefinition, StringComparison, bool> Enum => (type, _) => type.IsEnum;
        public static Func<TypeDefinition, StringComparison, bool> NotEnum => (type, _) => !Enum(type, _);

        public static Func<TypeDefinition, StringComparison, bool> Record => (type, _) => type.IsRecord;
        public static Func<TypeDefinition, StringComparison, bool> NotRecord => (type, _) => !Record(type, _);

        public static Func<TypeDefinition, StringComparison, bool> RecordStruct => (type, _) => type.IsRecordStruct;
        public static Func<TypeDefinition, StringComparison, bool> NotRecordStruct =>
            (type, _) => !RecordStruct(type, _);
    }
}
