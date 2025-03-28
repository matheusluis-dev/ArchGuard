namespace ArchGuard.Core.Predicates.Type
{
    using System;
    using ArchGuard.Core.Type.Models;

    public static partial class TypePredicate
    {
        public static Func<TypeDefinition, StringComparison, bool> Public => (type, _) => type.IsPublic;
        public static Func<TypeDefinition, StringComparison, bool> NotPublic => (type, _) => !type.IsPublic;

        public static Func<TypeDefinition, StringComparison, bool> Internal => (type, _) => type.IsInternal;
        public static Func<TypeDefinition, StringComparison, bool> NotInternal => (type, _) => !type.IsInternal;

        public static Func<TypeDefinition, StringComparison, bool> Private => (type, _) => type.IsPrivate;
        public static Func<TypeDefinition, StringComparison, bool> NotPrivate => (type, _) => !Private(type, _);

        public static Func<TypeDefinition, StringComparison, bool> Protected => (type, _) => type.IsProtected;
        public static Func<TypeDefinition, StringComparison, bool> NotProtected => (type, _) => !Protected(type, _);

        public static Func<TypeDefinition, StringComparison, bool> FileLocal => (type, _) => type.IsFileLocal;
        public static Func<TypeDefinition, StringComparison, bool> NotFileLocal => (type, _) => !type.IsFileLocal;
    }
}
