namespace ArchGuard.Core.Helpers
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal static class MethodSymbolHelper
    {
        private static IEnumerable<IMethodSymbol> GetCalledMethods(
            ProjectDefinition project,
            IMethodSymbol methodSymbol
        )
        {
            ArgumentNullException.ThrowIfNull(project);
            ArgumentNullException.ThrowIfNull(methodSymbol);

            (var methodSyntax, var semanticModel) = SymbolHelper.GetSemanticModel(
                methodSymbol,
                project
            );
            return methodSyntax
                .DescendantNodes()
                .OfType<InvocationExpressionSyntax>()
                .Select(invocation => semanticModel.GetSymbolInfo(invocation).Symbol)
                .OfType<IMethodSymbol>();
        }

        internal static IEnumerable<INamedTypeSymbol> GetAssignmentsTypes(
            ProjectDefinition project,
            IMethodSymbol methodSymbol
        )
        {
            ArgumentNullException.ThrowIfNull(project);
            ArgumentNullException.ThrowIfNull(methodSymbol);

            var types = new HashSet<INamedTypeSymbol>(SymbolEqualityComparer.Default);

            (var methodSyntax, var semanticModel) = SymbolHelper.GetSemanticModel(
                methodSymbol,
                project
            );

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
            ProjectDefinition project,
            IMethodSymbol methodSymbol
        )
        {
            ArgumentNullException.ThrowIfNull(project);
            ArgumentNullException.ThrowIfNull(methodSymbol);

            var types = new HashSet<INamedTypeSymbol>(SymbolEqualityComparer.Default);

            (var methodSyntax, var semanticModel) = SymbolHelper.GetSemanticModel(
                methodSymbol,
                project
            );

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

        public static IEnumerable<ITypeSymbol> GetParametersTypes(IMethodSymbol methodSymbol)
        {
            ArgumentNullException.ThrowIfNull(methodSymbol);

            return methodSymbol
                .Parameters.Select(parameter => parameter.Type)
                .OfType<ITypeSymbol>();
        }

        public static IEnumerable<ITypeSymbol> GetTypesInBody(
            ProjectDefinition project,
            IMethodSymbol methodSymbol
        )
        {
            ArgumentNullException.ThrowIfNull(methodSymbol);

            (var syntax, var semanticModel) = SymbolHelper.GetSemanticModel(methodSymbol, project);

            return syntax
                .DescendantNodes()
                .OfType<IdentifierNameSyntax>()
                .Select(identifier => semanticModel.GetSymbolInfo(identifier).Symbol)
                .OfType<ITypeSymbol>();
        }

        public static IEnumerable<ITypeSymbol> GetDependencies(
            ProjectDefinition project,
            IMethodSymbol method
        )
        {
            ArgumentNullException.ThrowIfNull(project);
            ArgumentNullException.ThrowIfNull(method);

            if (!SymbolHelper.HasDeclaringSyntaxReferences(method))
                return [];

            (var syntax, var semanticModel) = SymbolHelper.GetSemanticModel(method, project);

            var dependencies = new HashSet<ITypeSymbol>(SymbolEqualityComparer.Default);

            dependencies.Add(method.ReturnType);
            dependencies.UnionWith(GetParametersTypes(method));
            dependencies.UnionWith(GetTypesInBody(project, method));

            dependencies.UnionWith(
                syntax
                    .DescendantNodes()
                    .OfType<InvocationExpressionSyntax>()
                    .Select(invocation => semanticModel.GetSymbolInfo(invocation).Symbol)
                    .OfType<IMethodSymbol>()
                    .SelectMany(calledMethod => GetDependencies(project, calledMethod))
            );

            return dependencies;
        }
    }
}
