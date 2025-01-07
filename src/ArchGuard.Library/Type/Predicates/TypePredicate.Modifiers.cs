namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using ArchGuard.Library.Extensions.Type;

    internal static partial class TypePredicate
    {
        internal static Func<Type, StringComparison, bool> Partial { get; } =
            (type, comparison) => type.IsPartial(comparison);
        internal static Func<Type, StringComparison, bool> NotPartial { get; } =
            (type, comparison) => type.IsNotPartial(comparison);

        internal static Func<Type, StringComparison, bool> Sealed { get; } =
            (type, _) => type.IsSealed();
        internal static Func<Type, StringComparison, bool> NotSealed { get; } =
            (type, _) => type.IsNotSealed();

        internal static Func<Type, StringComparison, bool> Nested { get; } =
            (type, _) => type.IsNested;
        internal static Func<Type, StringComparison, bool> NotNested { get; } =
            (type, _) => !type.IsNested;

        internal static Func<Type, StringComparison, bool> Static { get; } =
            (type, _) => type.IsStatic();
        internal static Func<Type, StringComparison, bool> NotStatic { get; } =
            (type, _) => type.IsNotStatic();
    }
}
