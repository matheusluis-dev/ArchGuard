namespace ArchGuard.Library.Cached
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using ArchGuard.Library.Extensions;
    using Microsoft.CodeAnalysis;

    internal static class DependencySearchCached
    {
        private static readonly ConcurrentDictionary<
            TypeDefinition,
            IEnumerable<TypeDefinition>
        > _cache = new();

        private static readonly ConcurrentDictionary<TypeDefinition, SemaphoreSlim> _locks = new();

        internal static IEnumerable<TypeDefinition> GetDependencies(TypeDefinition typeDefinition)
        {
            ArgumentNullException.ThrowIfNull(typeDefinition);

            var namedTypeSymbol = typeDefinition.Symbol;
            var project = typeDefinition.Project;

            var semaphore = _locks.GetOrAdd(typeDefinition, _ => new SemaphoreSlim(1, 1));
            semaphore.Wait();

            try
            {
                if (_cache.TryGetValue(typeDefinition, out var result))
                    return result;

                var fieldDependencies = namedTypeSymbol
                    .GetMembers()
                    .OfType<IFieldSymbol>()
                    .Select(field => field.Type)
                    .OfType<INamedTypeSymbol>()
                    .Where(type =>
                        typeDefinition
                            .GetAllTypesFromProject()
                            .Any(typeDefinition =>
                                typeDefinition.Symbol.Equals(type, SymbolEqualityComparer.Default)
                            )
                    )
                    .Where(type => !type.Equals(typeDefinition))
                    .Select(type => new TypeDefinition(project, type));

                var propertyDependencies = namedTypeSymbol
                    .GetMembers()
                    .OfType<IPropertySymbol>()
                    .Select(property => property.Type)
                    .OfType<INamedTypeSymbol>()
                    .Where(type =>
                        typeDefinition
                            .GetAllTypesFromProject()
                            .Any(typeDefinition =>
                                typeDefinition.Symbol.Equals(type, SymbolEqualityComparer.Default)
                            )
                    )
                    .Where(type => !type.Equals(typeDefinition))
                    .Select(type => new TypeDefinition(project, type));

                var methods = namedTypeSymbol
                    .GetMembers()
                    .OfType<IMethodSymbol>()
                    .Where(method => !method.IsImplicitlyDeclared);
                var methodsDependencies = methods.SelectMany(method =>
                    method.GetDependencies(typeDefinition)
                );

                var dependencies = new HashSet<TypeDefinition>();
                dependencies.UnionWith(fieldDependencies);
                dependencies.UnionWith(propertyDependencies);
                dependencies.UnionWith(methodsDependencies);

                foreach (var dependency in new HashSet<TypeDefinition>(dependencies))
                    dependencies.UnionWith(GetDependencies(dependency));

                _cache.TryAdd(typeDefinition, dependencies);

                return dependencies;
            }
            finally
            {
                semaphore.Release();
                _locks.TryRemove(typeDefinition, out _);
            }
        }
    }
}
