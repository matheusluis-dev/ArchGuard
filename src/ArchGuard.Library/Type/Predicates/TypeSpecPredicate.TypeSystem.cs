namespace ArchGuard.Library.Type.Predicates
{
    using System;

    internal static partial class TypeSpecPredicate
    {
        internal static Func<TypeSpecRoslyn, StringComparison, bool> Class =>
            (type, _) => type.IsClass;
        internal static Func<TypeSpecRoslyn, StringComparison, bool> NotClass =>
            (type, comparison) => !Class(type, comparison);

        internal static Func<TypeSpecRoslyn, StringComparison, bool> Interface =>
            (type, _) => type.IsInterface;
        internal static Func<TypeSpecRoslyn, StringComparison, bool> NotInterface =>
            (type, _) => !Interface(type, _);

        internal static Func<TypeSpecRoslyn, StringComparison, bool> Struct =>
            (type, _) => type.IsStruct;
        internal static Func<TypeSpecRoslyn, StringComparison, bool> NotStruct =>
            (type, _) => !Struct(type, _);

        internal static Func<TypeSpecRoslyn, StringComparison, bool> Enum =>
            (type, _) => type.IsEnum;
        internal static Func<TypeSpecRoslyn, StringComparison, bool> NotEnum =>
            (type, _) => !Enum(type, _);

        internal static Func<TypeSpecRoslyn, StringComparison, bool> Record =>
            (type, _) => type.IsRecord;
        internal static Func<TypeSpecRoslyn, StringComparison, bool> NotRecord =>
            (type, _) => !Record(type, _);
    }
}
