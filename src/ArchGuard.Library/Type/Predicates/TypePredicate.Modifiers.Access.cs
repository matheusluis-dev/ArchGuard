namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using ArchGuard.Library.Extensions.Type;

    internal static partial class TypePredicate
    {
        internal static Func<Type, StringComparison, bool> Public { get; } =
            (type, _) => type.IsPublic();
        internal static Func<Type, StringComparison, bool> NotPublic { get; } =
            (type, _) => type.IsNotPublic();

        internal static Func<Type, StringComparison, bool> Internal { get; } =
            (type, comparison) => type.IsInternal(comparison);
        internal static Func<Type, StringComparison, bool> NotInternal { get; } =
            (type, comparison) => type.IsNotInternal(comparison);

        internal static Func<Type, StringComparison, bool> Private { get; } =
            (type, _) => type.IsPrivate();
        internal static Func<Type, StringComparison, bool> NotPrivate { get; } =
            (type, _) => type.IsNotPrivate();

        internal static Func<Type, StringComparison, bool> Protected { get; } =
            (type, _) => type.IsProtected();
        internal static Func<Type, StringComparison, bool> NotProtected { get; } =
            (type, _) => type.IsNotProtected();

#if NET7_0_OR_GREATER
        internal static Func<Type, StringComparison, bool> FileScoped { get; } =
            (type, comparison) => type.IsFileScoped(comparison);
        internal static Func<Type, StringComparison, bool> NotFileScoped { get; } =
            (type, comparison) => type.IsNotFileScoped(comparison);
#endif
    }
}
