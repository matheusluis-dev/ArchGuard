namespace ArchGuard.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Core.Helpers;
    using ArchGuard.Core.Type.Models;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public static class IMethodSymbolExtensions
    {
        public static IEnumerable<TypeDefinition> GetDependencies(
            this IMethodSymbol methodSymbol,
            TypeDefinition typeDefinition
        )
        {
            ArgumentNullException.ThrowIfNull(methodSymbol);
            ArgumentNullException.ThrowIfNull(typeDefinition);

            var project = typeDefinition.Project;

            if (!SymbolHelper.HasDeclaringSyntaxReferences(methodSymbol))
                return [];

            (var syntax, var semanticModel) = methodSymbol.GetSemanticModel(project);

            var dependencies = new HashSet<TypeDefinition>();

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
                            typeDefinition
                                .GetAllTypesFromProject()
                                .Any(typeDefinition =>
                                    typeDefinition.Symbol.Equals(
                                        type,
                                        SymbolEqualityComparer.Default
                                    )
                                )
                        )
                        .Where(type => !type.Equals(typeDefinition))
                        .Select(type => new TypeDefinition(project, type))
                );
            }

            void CheckReturnType()
            {
                if (
                    methodSymbol.ReturnType is INamedTypeSymbol methodReturnType
                    && typeDefinition
                        .GetAllTypesFromProject()
                        .Where(type => !type.Equals(typeDefinition))
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
                            typeDefinition
                                .GetAllTypesFromProject()
                                .Any(typeDefinition =>
                                    typeDefinition.Symbol.Equals(
                                        type,
                                        SymbolEqualityComparer.Default
                                    )
                                )
                        )
                        .Where(type => !type.Equals(typeDefinition))
                        .Select(type => new TypeDefinition(project, type))
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
                        .SelectMany(calledMethod => calledMethod.GetDependencies(typeDefinition))
                );
            }
        }
    }
}
