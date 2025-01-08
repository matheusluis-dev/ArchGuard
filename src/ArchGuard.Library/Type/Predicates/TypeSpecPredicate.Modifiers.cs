namespace ArchGuard.Library.Type.Predicates
{
    using System;

    internal static partial class TypeSpecPredicate
    {
        internal static Func<TypeSpecRoslyn, StringComparison, bool> Partial =>
            (type, _) => type.IsPartial;
        internal static Func<TypeSpecRoslyn, StringComparison, bool> NotPartial =>
            (type, _) => !Partial(type, _);

        internal static Func<TypeSpecRoslyn, StringComparison, bool> Sealed =>
            (type, _) => type.IsSealed;
        internal static Func<TypeSpecRoslyn, StringComparison, bool> NotSealed =>
            (type, _) => !Sealed(type, _);

        internal static Func<TypeSpecRoslyn, StringComparison, bool> Nested =>
            (type, _) => type.IsNested;
        internal static Func<TypeSpecRoslyn, StringComparison, bool> NotNested =>
            (type, _) => !Nested(type, _);

        internal static Func<TypeSpecRoslyn, StringComparison, bool> Static =>
            (type, _) => type.IsStatic;
        internal static Func<TypeSpecRoslyn, StringComparison, bool> NotStatic =>
            (type, _) => !Static(type, _);
    }
}
