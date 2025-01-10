namespace ArchGuard.Library.Type.Predicates
{
    using System;

    internal static partial class TypeSpecPredicate
    {
        internal static Func<TypeSpecRoslyn, StringComparison, bool> Public =>
            (type, _) => type.IsPublic;
        internal static Func<TypeSpecRoslyn, StringComparison, bool> NotPublic =>
            (type, _) => !Public(type, _);

        internal static Func<TypeSpecRoslyn, StringComparison, bool> Internal =>
            (type, _) => type.IsInternal;
        internal static Func<TypeSpecRoslyn, StringComparison, bool> NotInternal =>
            (type, _) => !Internal(type, _);

        internal static Func<TypeSpecRoslyn, StringComparison, bool> Private =>
            (type, _) => type.IsPrivate;
        internal static Func<TypeSpecRoslyn, StringComparison, bool> NotPrivate =>
            (type, _) => !Private(type, _);

        internal static Func<TypeSpecRoslyn, StringComparison, bool> Protected =>
            (type, _) => type.IsProtected;
        internal static Func<TypeSpecRoslyn, StringComparison, bool> NotProtected =>
            (type, _) => !Protected(type, _);

        internal static Func<TypeSpecRoslyn, StringComparison, bool> FileScoped =>
            (type, _) => type.IsFileScoped;
        internal static Func<TypeSpecRoslyn, StringComparison, bool> NotFileScoped =>
            (type, _) => !FileScoped(type, _);
    }
}
