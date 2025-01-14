namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal static partial class TypePredicate
    {
        internal static Func<Type_, StringComparison, bool> Partial =>
            (type, _) =>
                type
                    .Symbol.DeclaringSyntaxReferences.Select(reference => reference.GetSyntax())
                    .OfType<TypeDeclarationSyntax>()
                    .Any(syntax => syntax.Modifiers.Any(SyntaxKind.PartialKeyword));
        internal static Func<Type_, StringComparison, bool> NotPartial =>
            (type, _) => !Partial(type, _);

        internal static Func<Type_, StringComparison, bool> Sealed =>
            (type, _) => type.Symbol.IsSealed;
        internal static Func<Type_, StringComparison, bool> NotSealed =>
            (type, _) => !Sealed(type, _);

        internal static Func<Type_, StringComparison, bool> Nested =>
            (type, _) => type.Symbol.ContainingType != null;
        internal static Func<Type_, StringComparison, bool> NotNested =>
            (type, _) => !Nested(type, _);

        internal static Func<Type_, StringComparison, bool> Static =>
            (type, _) => type.Symbol.IsStatic;
        internal static Func<Type_, StringComparison, bool> NotStatic =>
            (type, _) => !Static(type, _);
    }
}
