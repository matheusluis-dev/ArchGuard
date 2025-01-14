namespace ArchGuard.Library.Extensions
{
    using System;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public static class IMethodSymbolExtensions
    {
        public static bool ExternallyAltersState(this IMethodSymbol methodSymbol, Project project)
        {
            ArgumentNullException.ThrowIfNull(methodSymbol);
            ArgumentNullException.ThrowIfNull(project);

            if (methodSymbol.MethodKind == MethodKind.Constructor)
                return false;

            if (methodSymbol.IsPrivateOrProtected())
                return false;

            var syntaxReference = methodSymbol.DeclaringSyntaxReferences.FirstOrDefault();
            if (syntaxReference is null)
                return false;

            if (syntaxReference.GetSyntax() is not MethodDeclarationSyntax methodSyntax)
                return false;

            var compilation = project.GetCompilationAsync().Result;

            var syntaxTree = methodSyntax.SyntaxTree;
            var semanticModel = compilation.GetSemanticModel(syntaxTree);
            if (semanticModel == null)
                return false;

            // Check for assignment expressions that modify private fields or properties
            var assignments = methodSyntax
                .DescendantNodes()
                .OfType<AssignmentExpressionSyntax>()
                .Select(assignment => semanticModel.GetSymbolInfo(assignment.Left).Symbol)
                .Where(symbol =>
                    symbol != null
                    && (symbol.Kind == SymbolKind.Field || symbol.Kind == SymbolKind.Property)
                )
                .Where(symbol => symbol.DeclaredAccessibility == Accessibility.Private);

            if (assignments.Any())
            {
                return true;
            }

            // Check for member access expressions that modify private fields and properties
            var memberAccesses = methodSyntax
                .DescendantNodes()
                .OfType<MemberAccessExpressionSyntax>()
                .Select(memberAccess => semanticModel.GetSymbolInfo(memberAccess).Symbol)
                .Where(symbol =>
                    symbol != null
                    && (symbol.Kind == SymbolKind.Field || symbol.Kind == SymbolKind.Property)
                )
                .Where(symbol => symbol.DeclaredAccessibility == Accessibility.Private);

            if (memberAccesses.Any())
            {
                return true;
            }

            // Check if any called methods alter private state
            var altersState = methodSyntax
                .DescendantNodes()
                .OfType<InvocationExpressionSyntax>()
                .Select(invocation =>
                    semanticModel.GetSymbolInfo(invocation).Symbol as IMethodSymbol
                )
                .Where(calledMethod => calledMethod != null)
                .Any(calledMethod => calledMethod.ExternallyAltersState(project));

            return altersState;
        }
    }
}
