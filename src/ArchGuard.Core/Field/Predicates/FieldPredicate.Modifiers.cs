namespace ArchGuard.Core.Field.Predicates
{
    using ArchGuard.Core.Field.Models;

    public static partial class FieldPredicate
    {
        public static Func<FieldDefinition, StringComparison, bool> Static => (field, _) => field.IsStatic;

        public static Func<FieldDefinition, StringComparison, bool> NotStatic => (field, _) => !Static(field, _);

        public static Func<FieldDefinition, StringComparison, bool> Const =>
            // .IsConst returns true if type is also an Enum
            (field, _) => field.IsConst && field.Type.IsEnum;

        public static Func<FieldDefinition, StringComparison, bool> NotConst => (field, _) => !Const(field, _);

        public static Func<FieldDefinition, StringComparison, bool> Readonly => (field, _) => field.IsReadOnly;

        public static Func<FieldDefinition, StringComparison, bool> NotReadonly => (field, _) => !Readonly(field, _);
    }
}
