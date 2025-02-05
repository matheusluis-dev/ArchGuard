namespace ArchGuard.Core.Helpers
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal static class MethodSymbolHelper
    {
        private static IEnumerable<IMethodSymbol> GetCalledMethods(
            Project project,
            IMethodSymbol methodSymbol
        )
        {
            ArgumentNullException.ThrowIfNull(project);
            ArgumentNullException.ThrowIfNull(methodSymbol);

            (var methodSyntax, var semanticModel) = methodSymbol.GetSemanticModel(project);

            return methodSyntax
                .DescendantNodes()
                .OfType<InvocationExpressionSyntax>()
                .Select(invocation => semanticModel.GetSymbolInfo(invocation).Symbol)
                .OfType<IMethodSymbol>();
        }

        internal static IEnumerable<INamedTypeSymbol> GetAssignmentsTypes(
            Project project,
            IMethodSymbol methodSymbol
        )
        {
            ArgumentNullException.ThrowIfNull(project);
            ArgumentNullException.ThrowIfNull(methodSymbol);

            var types = new HashSet<INamedTypeSymbol>(SymbolEqualityComparer.Default);

            (var methodSyntax, var semanticModel) = methodSymbol.GetSemanticModel(project);

            foreach (var calledMethodSymbol in GetCalledMethods(project, methodSymbol))
            {
                types.UnionWith(GetAssignmentsTypes(project, calledMethodSymbol));
            }

            types.UnionWith(
                methodSyntax
                    .DescendantNodes()
                    .OfType<AssignmentExpressionSyntax>()
                    .Select(assignment => semanticModel.GetSymbolInfo(assignment.Left).Symbol)
                    .OfType<INamedTypeSymbol>()
            );

            return types;
        }

        internal static IEnumerable<INamedTypeSymbol> GetPropertiesAccessorsTypes(
            Project project,
            IMethodSymbol methodSymbol
        )
        {
            ArgumentNullException.ThrowIfNull(project);
            ArgumentNullException.ThrowIfNull(methodSymbol);

            var types = new HashSet<INamedTypeSymbol>(SymbolEqualityComparer.Default);

            (var methodSyntax, var semanticModel) = methodSymbol.GetSemanticModel(project);

            foreach (var calledMethodSymbol in GetCalledMethods(project, methodSymbol))
            {
                types.UnionWith(GetPropertiesAccessorsTypes(project, calledMethodSymbol));
            }

            types.UnionWith(
                methodSyntax
                    .DescendantNodes()
                    .OfType<IdentifierNameSyntax>()
                    .Select(memberAccess => semanticModel.GetSymbolInfo(memberAccess).Symbol)
                    .OfType<IPropertySymbol>()
                    .Select(property => property.Type)
                    .OfType<INamedTypeSymbol>()
            );

            return types;
        }

        internal static bool ExternallyAltersState(
            IMethodSymbol methodSymbol,
            Project project,
            bool ignorePrivateOrProtectedVerification = false
        )
        {
            ArgumentNullException.ThrowIfNull(methodSymbol);
            ArgumentNullException.ThrowIfNull(project);

            if (methodSymbol.MethodKind is not MethodKind.Ordinary)
                return false;

            if (
                !ignorePrivateOrProtectedVerification
                && SymbolHelper.IsPrivateOrProtected(methodSymbol)
            )
            {
                return false;
            }

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
                            SymbolHelper.IsPrivateOrProtected(symbol)
                            || (
                                symbol is IPropertySymbol propertySymbol
                                && propertySymbol.HasSetMethod()
                                && SymbolHelper.IsPrivateOrProtected(propertySymbol.SetMethod!)
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
    }
}
