namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using System.Linq;
    using ArchGuard.Library.Type;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal static partial class TypeDefinitionPredicate
    {
        internal static Func<TypeDefinition, StringComparison, bool> Partial =>
            (type, _) =>
                type
                    .Symbol.DeclaringSyntaxReferences.Select(reference => reference.GetSyntax())
                    .OfType<TypeDeclarationSyntax>()
                    .Any(syntax => syntax.Modifiers.Any(SyntaxKind.PartialKeyword));
        internal static Func<TypeDefinition, StringComparison, bool> NotPartial =>
            (type, _) => !Partial(type, _);

        internal static Func<TypeDefinition, StringComparison, bool> Sealed =>
            (type, _) => type.Symbol.IsSealed;
        internal static Func<TypeDefinition, StringComparison, bool> NotSealed =>
            (type, _) => !Sealed(type, _);

        internal static Func<TypeDefinition, StringComparison, bool> Nested =>
            (type, _) => type.Symbol.ContainingType != null;
        internal static Func<TypeDefinition, StringComparison, bool> NotNested =>
            (type, _) => !Nested(type, _);

        internal static Func<TypeDefinition, StringComparison, bool> Static =>
            (type, _) => type.Symbol.IsStatic;
        internal static Func<TypeDefinition, StringComparison, bool> NotStatic =>
            (type, _) => !Static(type, _);
    }
}
