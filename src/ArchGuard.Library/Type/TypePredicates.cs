namespace ArchGuard.Library.Type
{
    using System;
    using ArchGuard.Library.Extensions.Type;

    internal static class TypePredicates
    {
        internal static Func<Type, bool> Public { get; } = type => type.IsPublic();
        internal static Func<Type, bool> NotPublic { get; } = type => type.IsNotPublic();

        internal static Func<Type, bool> Internal { get; } = type => type.IsInternal();
        internal static Func<Type, bool> NotInternal { get; } = type => type.IsNotInternal();

        internal static Func<Type, bool> Private { get; } = type => type.IsPrivate();
        internal static Func<Type, bool> NotPrivate { get; } = type => type.IsNotPrivate();

        internal static Func<Type, bool> Protected { get; } = type => type.IsProtected();
        internal static Func<Type, bool> NotProtected { get; } = type => type.IsNotProtected();

#if NET7_0_OR_GREATER
        internal static Func<Type, bool> FileScoped { get; } = type => type.IsFileScoped();
        internal static Func<Type, bool> NotFileScoped { get; } = type => type.IsNotFileScoped();
#endif
    }
}
