namespace ArchGuardType.Predicates
{
    using System;
    using ArchGuard.Kernel.Models;
    using Microsoft.CodeAnalysis;

    internal static partial class TypePredicate
    {
        internal static Func<TypeDefinition, StringComparison, bool> Public =>
            (type, _) => type.Symbol.DeclaredAccessibility == Accessibility.Public;
        internal static Func<TypeDefinition, StringComparison, bool> NotPublic =>
            (type, _) => !Public(type, _);

        internal static Func<TypeDefinition, StringComparison, bool> Internal =>
            (type, _) =>
                NotFileScoped(type, _)
                && (
                    type.Symbol.DeclaredAccessibility == Accessibility.Internal
                    || type.Symbol.DeclaredAccessibility == Accessibility.Friend
                );
        internal static Func<TypeDefinition, StringComparison, bool> NotInternal =>
            (type, _) => !Internal(type, _);

        internal static Func<TypeDefinition, StringComparison, bool> Private =>
            (type, _) => type.Symbol.DeclaredAccessibility == Accessibility.Private;
        internal static Func<TypeDefinition, StringComparison, bool> NotPrivate =>
            (type, _) => !Private(type, _);

        internal static Func<TypeDefinition, StringComparison, bool> Protected =>
            (type, _) => type.Symbol.DeclaredAccessibility == Accessibility.Protected;
        internal static Func<TypeDefinition, StringComparison, bool> NotProtected =>
            (type, _) => !Protected(type, _);

        internal static Func<TypeDefinition, StringComparison, bool> FileScoped =>
            (type, _) => type.Symbol.IsFileLocal;
        internal static Func<TypeDefinition, StringComparison, bool> NotFileScoped =>
            (type, _) => !FileScoped(type, _);
    }
}
