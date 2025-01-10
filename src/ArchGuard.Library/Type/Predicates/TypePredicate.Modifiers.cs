namespace ArchGuard.Library
{
    using System;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal static partial class TypePredicate
    {
        internal static Func<INamedTypeSymbol, StringComparison, bool> Partial =>
            (type, _) =>
                type
                    .DeclaringSyntaxReferences.Select(reference => reference.GetSyntax())
                    .OfType<TypeDeclarationSyntax>()
                    .Any(syntax => syntax.Modifiers.Any(SyntaxKind.PartialKeyword));
        internal static Func<INamedTypeSymbol, StringComparison, bool> NotPartial =>
            (type, _) => !Partial(type, _);

        internal static Func<INamedTypeSymbol, StringComparison, bool> Sealed =>
            (type, _) => type.IsSealed;
        internal static Func<INamedTypeSymbol, StringComparison, bool> NotSealed =>
            (type, _) => !Sealed(type, _);

        internal static Func<INamedTypeSymbol, StringComparison, bool> Nested =>
            (type, _) => type.ContainingType != null;
        internal static Func<INamedTypeSymbol, StringComparison, bool> NotNested =>
            (type, _) => !Nested(type, _);

        internal static Func<INamedTypeSymbol, StringComparison, bool> Static =>
            (type, _) => type.IsStatic;
        internal static Func<INamedTypeSymbol, StringComparison, bool> NotStatic =>
            (type, _) => !Static(type, _);
    }
}
