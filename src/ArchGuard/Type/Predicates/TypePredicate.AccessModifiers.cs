namespace ArchGuard
{
    using System;
    using ArchGuard.Extensions;
    using ArchGuard.Kernel.Models;
    using Microsoft.CodeAnalysis;

    internal static partial class TypePredicate
    {
        internal static Func<TypeDefinition, StringComparison, bool> Public =>
            (type, _) => type.IsPublic();
        internal static Func<TypeDefinition, StringComparison, bool> NotPublic =>
            (type, _) => !type.IsPublic();

        internal static Func<TypeDefinition, StringComparison, bool> Internal =>
            (type, _) => type.IsInternal();
        internal static Func<TypeDefinition, StringComparison, bool> NotInternal =>
            (type, _) => !type.IsInternal();

        internal static Func<TypeDefinition, StringComparison, bool> Private =>
            (type, _) => type.Symbol.DeclaredAccessibility == Accessibility.Private;
        internal static Func<TypeDefinition, StringComparison, bool> NotPrivate =>
            (type, _) => !Private(type, _);

        internal static Func<TypeDefinition, StringComparison, bool> Protected =>
            (type, _) => type.Symbol.DeclaredAccessibility == Accessibility.Protected;
        internal static Func<TypeDefinition, StringComparison, bool> NotProtected =>
            (type, _) => !Protected(type, _);

        internal static Func<TypeDefinition, StringComparison, bool> FileLocal =>
            (type, _) => type.IsFileLocal();
        internal static Func<TypeDefinition, StringComparison, bool> NotFileLocal =>
            (type, _) => !type.IsFileLocal();
    }
}
