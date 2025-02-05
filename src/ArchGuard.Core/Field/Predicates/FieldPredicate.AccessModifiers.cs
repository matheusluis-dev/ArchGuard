namespace ArchGuard.Core.Field.Predicates
{
    using ArchGuard.Core.Field.Models;

    public static partial class FieldPredicate
    {
        public static Func<FieldDefinition, StringComparison, bool> Public =>
            (field, _) => field.IsPublic;

        public static Func<FieldDefinition, StringComparison, bool> NotPublic =>
            (field, _) => !Public(field, _);

        public static Func<FieldDefinition, StringComparison, bool> Internal =>
            (field, _) => field.IsInternal;

        public static Func<FieldDefinition, StringComparison, bool> NotInternal =>
            (field, _) => !Internal(field, _);

        public static Func<FieldDefinition, StringComparison, bool> Protected =>
            (field, _) => field.IsProtected;

        public static Func<FieldDefinition, StringComparison, bool> NotProtected =>
            (field, _) => !Protected(field, _);

        public static Func<FieldDefinition, StringComparison, bool> Private =>
            (field, _) => field.IsPrivate;

        public static Func<FieldDefinition, StringComparison, bool> NotPrivate =>
            (field, _) => !Private(field, _);
    }
}
