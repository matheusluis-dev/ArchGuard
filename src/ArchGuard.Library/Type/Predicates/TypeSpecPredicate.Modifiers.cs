namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using ArchGuard.Library.Extensions.Type;

    internal static partial class TypeSpecPredicate
    {
        internal static Func<TypeSpec, StringComparison, bool> Partial { get; } =
            (type, _) => type.IsPartial;
        internal static Func<TypeSpec, StringComparison, bool> NotPartial { get; } =
            (type, _) => !type.IsPartial;

        internal static Func<TypeSpec, StringComparison, bool> Sealed { get; } =
            (type, _) => type.ReflectionType.IsSealed();
        internal static Func<TypeSpec, StringComparison, bool> NotSealed { get; } =
            (type, _) => type.ReflectionType.IsNotSealed();

        internal static Func<TypeSpec, StringComparison, bool> Nested { get; } =
            (type, _) => type.ReflectionType.IsNested;
        internal static Func<TypeSpec, StringComparison, bool> NotNested { get; } =
            (type, _) => !type.ReflectionType.IsNested;

        internal static Func<TypeSpec, StringComparison, bool> Static { get; } =
            (type, _) => type.ReflectionType.IsStatic();
        internal static Func<TypeSpec, StringComparison, bool> NotStatic { get; } =
            (type, _) => type.ReflectionType.IsNotStatic();
    }
}
