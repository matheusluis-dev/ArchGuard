namespace ArchGuard.Core.Predicates.Type
{
    using System;
    using ArchGuard.Core.Type.Models;

    public static partial class TypePredicate
    {
        public static Func<TypeDefinition, StringComparison, bool> Partial => (type, _) => type.IsPartial;
        public static Func<TypeDefinition, StringComparison, bool> NotPartial => (type, _) => !Partial(type, _);

        public static Func<TypeDefinition, StringComparison, bool> Sealed => (type, _) => type.IsSealed;
        public static Func<TypeDefinition, StringComparison, bool> NotSealed => (type, _) => !Sealed(type, _);

        public static Func<TypeDefinition, StringComparison, bool> Nested => (type, _) => type.IsNested;
        public static Func<TypeDefinition, StringComparison, bool> NotNested => (type, _) => !Nested(type, _);

        public static Func<TypeDefinition, StringComparison, bool> Static => (type, _) => type.IsStatic;
        public static Func<TypeDefinition, StringComparison, bool> NotStatic => (type, _) => !Static(type, _);

        public static Func<TypeDefinition, StringComparison, bool> Abstract => (type, _) => type.IsAbstract;
        public static Func<TypeDefinition, StringComparison, bool> NotAbstract => (type, _) => !Abstract(type, _);
    }
}
