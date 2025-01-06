namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using ArchGuard.Library.Extensions.Type;

    internal static partial class TypePredicate
    {
        internal static Func<Type, bool> Partial { get; } = type => type.IsPartial();
        internal static Func<Type, bool> NotPartial { get; } = type => type.IsNotPartial();

        internal static Func<Type, bool> Sealed { get; } = type => type.IsSealed();
        internal static Func<Type, bool> NotSealed { get; } = type => type.IsNotSealed();

        internal static Func<Type, bool> Nested { get; } = type => type.IsNested;
        internal static Func<Type, bool> NotNested { get; } = type => !type.IsNested;

        internal static Func<Type, bool> Static { get; } = type => type.IsStatic();
        internal static Func<Type, bool> NotStatic { get; } = type => type.IsNotStatic();
    }
}
