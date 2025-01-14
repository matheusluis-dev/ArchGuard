namespace ArchGuard.Library.Extensions
{
    using System;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public static class IMethodSymbolExtensions
    {
        public static bool ExternallyAltersState(
            this IMethodSymbol methodSymbol,
            Project project,
            bool ignorePrivateOrProtectedVerification = false
        )
        {
            ArgumentNullException.ThrowIfNull(methodSymbol);
            ArgumentNullException.ThrowIfNull(project);

            if (methodSymbol.MethodKind is not MethodKind.Ordinary)
                return false;

            if (!ignorePrivateOrProtectedVerification && methodSymbol.IsPrivateOrProtected())
                return false;

            (var methodSyntax, var semanticModel) = methodSymbol.GetSemanticModel(project);

            return CheckAssignments() || CheckMemberAccesses() || CheckCalledMethods();

            // Check for assignment expressions that modify private fields or properties
            bool CheckAssignments()
            {
                return methodSyntax
                    .DescendantNodes()
                    .OfType<AssignmentExpressionSyntax>()
                    .Select(assignment => semanticModel.GetSymbolInfo(assignment.Left).Symbol)
                    .Any(symbol =>
                        symbol?.Kind is SymbolKind.Field or SymbolKind.Property
                        && (
                            symbol?.IsPrivateOrProtected() == true
                            || (
                                symbol is IPropertySymbol propertySymbol
                                && propertySymbol?.SetMethod?.IsPrivateOrProtected() == true
                            )
                        )
                    );
            }

            // Check for member access expressions that modify private fields and properties
            bool CheckMemberAccesses()
            {
                return methodSyntax
                    .DescendantNodes()
                    .OfType<MemberAccessExpressionSyntax>()
                    .Select(memberAccess => semanticModel.GetSymbolInfo(memberAccess).Symbol)
                    .Any(symbol =>
                        symbol?.IsPrivateOrProtected() == true
                        && symbol?.Kind is SymbolKind.Field or SymbolKind.Property
                    );
            }

            // Check if any called methods alter private state
            bool CheckCalledMethods()
            {
                return methodSyntax
                    .DescendantNodes()
                    .OfType<InvocationExpressionSyntax>()
                    .Select(invocation =>
                        semanticModel.GetSymbolInfo(invocation).Symbol as IMethodSymbol
                    )
                    .Any(calledMethod =>
                        calledMethod?.ExternallyAltersState(
                            project,
                            ignorePrivateOrProtectedVerification: true
                        ) == true
                    );
            }
        }
    }
}
