namespace ArchGuard.Core.Predicates.Type
{
    using System;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public static partial class TypePredicate
    {
        public static Func<TypeDefinition, StringComparison, bool> Partial =>
            (type, _) =>
                type
                    .Symbol.DeclaringSyntaxReferences.Select(reference => reference.GetSyntax())
                    .OfType<TypeDeclarationSyntax>()
                    .Any(syntax => syntax.Modifiers.Any(SyntaxKind.PartialKeyword));
        public static Func<TypeDefinition, StringComparison, bool> NotPartial =>
            (type, _) => !Partial(type, _);

        public static Func<TypeDefinition, StringComparison, bool> Sealed =>
            (type, _) => type.Symbol.IsSealed;
        public static Func<TypeDefinition, StringComparison, bool> NotSealed =>
            (type, _) => !Sealed(type, _);

        public static Func<TypeDefinition, StringComparison, bool> Nested =>
            (type, _) => type.Symbol.ContainingType != null;
        public static Func<TypeDefinition, StringComparison, bool> NotNested =>
            (type, _) => !Nested(type, _);

        public static Func<TypeDefinition, StringComparison, bool> Static =>
            (type, _) => type.Symbol.IsStatic;
        public static Func<TypeDefinition, StringComparison, bool> NotStatic =>
            (type, _) => !Static(type, _);
        public static Func<TypeDefinition, StringComparison, bool> Abstract =>
            (type, _) => type.Symbol.IsAbstract;
        public static Func<TypeDefinition, StringComparison, bool> NotAbstract =>
            (type, _) => !Abstract(type, _);
    }
}
