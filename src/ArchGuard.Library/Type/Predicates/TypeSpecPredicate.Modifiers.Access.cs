namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using ArchGuard.Library.Extensions.Type;

    internal static partial class TypeSpecPredicate
    {
        internal static Func<TypeSpec, StringComparison, bool> Public =>
            (type, _) => type.ReflectionType.IsPublic();
        internal static Func<TypeSpec, StringComparison, bool> NotPublic =>
            (type, _) => type.ReflectionType.IsNotPublic();

        internal static Func<TypeSpec, StringComparison, bool> Internal =>
            (type, _) => type.IsInternal;
        internal static Func<TypeSpec, StringComparison, bool> NotInternal =>
            (type, _) => !Internal(type, _);

        internal static Func<TypeSpec, StringComparison, bool> Private =>
            (type, _) => type.ReflectionType.IsPrivate();
        internal static Func<TypeSpec, StringComparison, bool> NotPrivate =>
            (type, _) => type.ReflectionType.IsNotPrivate();

        internal static Func<TypeSpec, StringComparison, bool> Protected =>
            (type, _) => type.ReflectionType.IsProtected();
        internal static Func<TypeSpec, StringComparison, bool> NotProtected =>
            (type, _) => type.ReflectionType.IsNotProtected();

#if NET7_0_OR_GREATER
        internal static Func<TypeSpec, StringComparison, bool> FileScoped =>
            (type, _) => type.IsFileScoped;
        internal static Func<TypeSpec, StringComparison, bool> NotFileScoped =>
            (type, _) => !FileScoped(type, _);
#endif
    }
}
