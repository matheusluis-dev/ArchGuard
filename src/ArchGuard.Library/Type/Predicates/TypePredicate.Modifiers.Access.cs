namespace ArchGuard.Library
{
    using System;
    using Microsoft.CodeAnalysis;

    internal static partial class TypePredicate
    {
        internal static Func<INamedTypeSymbol, StringComparison, bool> Public =>
            (type, _) => type.DeclaredAccessibility == Accessibility.Public;
        internal static Func<INamedTypeSymbol, StringComparison, bool> NotPublic =>
            (type, _) => !Public(type, _);

        internal static Func<INamedTypeSymbol, StringComparison, bool> Internal =>
            (type, _) =>
                NotFileScoped(type, _)
                && (
                    type.DeclaredAccessibility == Accessibility.Internal
                    || type.DeclaredAccessibility == Accessibility.Friend
                );
        internal static Func<INamedTypeSymbol, StringComparison, bool> NotInternal =>
            (type, _) => !Internal(type, _);

        internal static Func<INamedTypeSymbol, StringComparison, bool> Private =>
            (type, _) => type.DeclaredAccessibility == Accessibility.Private;
        internal static Func<INamedTypeSymbol, StringComparison, bool> NotPrivate =>
            (type, _) => !Private(type, _);

        internal static Func<INamedTypeSymbol, StringComparison, bool> Protected =>
            (type, _) => type.DeclaredAccessibility == Accessibility.Protected;
        internal static Func<INamedTypeSymbol, StringComparison, bool> NotProtected =>
            (type, _) => !Protected(type, _);

        internal static Func<INamedTypeSymbol, StringComparison, bool> FileScoped =>
            (type, _) => type.IsFileLocal;
        internal static Func<INamedTypeSymbol, StringComparison, bool> NotFileScoped =>
            (type, _) => !FileScoped(type, _);
    }
}
