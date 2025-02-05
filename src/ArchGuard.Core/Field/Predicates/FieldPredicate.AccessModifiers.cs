namespace ArchGuard.Core.Field.Predicates
{
    using ArchGuard.Core.Field.Models;
    using Microsoft.CodeAnalysis;

    public static partial class FieldPredicate
    {
        public static Func<FieldDefinition, StringComparison, bool> Public =>
            (type, _) => type.Symbol.DeclaredAccessibility is Accessibility.Public;

        public static Func<FieldDefinition, StringComparison, bool> NotPublic =>
            (type, _) => !Public(type, _);

        public static Func<FieldDefinition, StringComparison, bool> Internal =>
            (type, _) => type.Symbol.IsInternal();

        public static Func<FieldDefinition, StringComparison, bool> NotInternal =>
            (type, _) => !Internal(type, _);

        public static Func<FieldDefinition, StringComparison, bool> Protected =>
            (type, _) => type.Symbol.IsProtected();

        public static Func<FieldDefinition, StringComparison, bool> NotProtected =>
            (type, _) => !Protected(type, _);

        public static Func<FieldDefinition, StringComparison, bool> Private =>
            (type, _) => type.Symbol.IsPrivate();

        public static Func<FieldDefinition, StringComparison, bool> NotPrivate =>
            (type, _) => !Private(type, _);
    }
}
