namespace ArchGuard.Core.Helpers
{
    using ArchGuard.Core.Extensions;
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

            (var methodSyntax, var semanticModel) = methodSymbol.GetSemanticModel(project);

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
            ProjectDefinition project,
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
            ProjectDefinition project,
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
                                && propertySymbol.SetMethod is not null
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

        public static IEnumerable<INamedTypeSymbol> GetDependencies(
            this IMethodSymbol methodSymbol,
            INamedTypeSymbol type
        )
        {
            ArgumentNullException.ThrowIfNull(methodSymbol);
            ArgumentNullException.ThrowIfNull(type);

            var project = type.Project;

            if (!SymbolHelper.HasDeclaringSyntaxReferences(methodSymbol))
                return [];

            (var syntax, var semanticModel) = methodSymbol.GetSemanticModel(project);

            var dependencies = new HashSet<INamedTypeSymbol>(SymbolEqualityComparer.Default);

            CheckParameters();
            CheckReturnType();
            CheckBodyTypes();
            CheckCalledMethods();

            return dependencies;

            void CheckParameters()
            {
                dependencies.UnionWith(
                    methodSymbol
                        .Parameters.Select(parameter => parameter.Type)
                        .OfType<INamedTypeSymbol>()
                        .Where(type =>
                            type.GetAllTypesFromProject()
                                .Any(typeDefinition =>
                                    typeDefinition.Symbol.Equals(
                                        type,
                                        SymbolEqualityComparer.Default
                                    )
                                )
                        )
                        .Where(type => !type.Equals(type))
                        .Select(type => new INamedTypeSymbol(project, type))
                );
            }

            void CheckReturnType()
            {
                if (
                    methodSymbol.ReturnType is INamedTypeSymbol methodReturnType
                    && type.GetAllTypesFromProject()
                        .Where(type => !type.Equals(type))
                        .Any(typeDefinition =>
                            typeDefinition.Symbol.Equals(
                                methodReturnType,
                                SymbolEqualityComparer.Default
                            )
                        )
                )
                {
                    dependencies.Add(new(project, methodReturnType));
                }
            }

            void CheckBodyTypes()
            {
                dependencies.UnionWith(
                    syntax
                        .DescendantNodes()
                        .OfType<IdentifierNameSyntax>()
                        .Select(identifier => semanticModel.GetSymbolInfo(identifier).Symbol)
                        .OfType<INamedTypeSymbol>()
                        .Where(type =>
                            type.GetAllTypesFromProject()
                                .Any(typeDefinition =>
                                    typeDefinition.Symbol.Equals(
                                        type,
                                        SymbolEqualityComparer.Default
                                    )
                                )
                        )
                        .Where(type => !type.Equals(type))
                        .Select(type => new INamedTypeSymbol(project, type))
                );
            }

            void CheckCalledMethods()
            {
                dependencies.UnionWith(
                    syntax
                        .DescendantNodes()
                        .OfType<InvocationExpressionSyntax>()
                        .Select(invocation => semanticModel.GetSymbolInfo(invocation).Symbol)
                        .OfType<IMethodSymbol>()
                        .SelectMany(calledMethod => calledMethod.GetDependencies(type))
                );
            }
        }
    }
}
