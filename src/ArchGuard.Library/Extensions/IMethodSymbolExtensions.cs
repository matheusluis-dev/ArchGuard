namespace ArchGuard.Library.Extensions
{
    using System;
    using System.Collections.Generic;
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

            return CheckAssignments() || CheckPropertiesAccessors() || CheckCalledMethods();

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
            bool CheckPropertiesAccessors()
            {
                return methodSyntax
                    .DescendantNodes()
                    .OfType<IdentifierNameSyntax>()
                    .Select(memberAccess => semanticModel.GetSymbolInfo(memberAccess).Symbol)
                    .OfType<IPropertySymbol>()
                    .Any(property =>
                        property.IsExternallyImmutable(
                            project,
                            ignorePrivateOrProtectedVerification: true
                        )
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

        public static IEnumerable<INamedTypeSymbol> GetDependencies(
            this IMethodSymbol methodSymbol,
            Project project
        )
        {
            ArgumentNullException.ThrowIfNull(methodSymbol);
            ArgumentNullException.ThrowIfNull(project);

            if (!methodSymbol.HasDeclaringSyntaxReferences())
                return Enumerable.Empty<INamedTypeSymbol>();

            (var syntax, var semanticModel) = methodSymbol.GetSemanticModel(project);

            var dependencies = new HashSet<INamedTypeSymbol>();

            dependencies.UnionWith(
                methodSymbol
                    .Parameters.Select(parameter => parameter.Type)
                    .OfType<INamedTypeSymbol>()
            );

            if (methodSymbol.ReturnType is INamedTypeSymbol methodReturnType)
                dependencies.Add(methodReturnType);

            dependencies.UnionWith(
                syntax
                    .DescendantNodes()
                    .OfType<IdentifierNameSyntax>()
                    .Select(identifier => semanticModel.GetSymbolInfo(identifier).Symbol)
                    .OfType<INamedTypeSymbol>()
            );

            dependencies.UnionWith(
                syntax
                    .DescendantNodes()
                    .OfType<InvocationExpressionSyntax>()
                    .Select(invocation => semanticModel.GetSymbolInfo(invocation).Symbol)
                    .OfType<IMethodSymbol>()
                    .SelectMany(calledMethod => calledMethod.GetDependencies(project))
            );

            return dependencies;
        }
    }
}
