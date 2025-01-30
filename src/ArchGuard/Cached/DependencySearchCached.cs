namespace ArchGuard.Cached
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using ArchGuard.Extensions;
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

            var semaphore = _locks.GetOrAdd(typeDefinition, _ => new SemaphoreSlim(1, 1));
            semaphore.Wait();

            try
            {
                if (_cache.TryGetValue(typeDefinition, out var result))
                    return result;

                var dependencies = new HashSet<TypeDefinition>();

                dependencies.UnionWith(GetFieldsDependencies(typeDefinition));
                dependencies.UnionWith(GetPropertiesDependencies(typeDefinition));
                dependencies.UnionWith(GetMethodsDependencies(typeDefinition));

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

        private static IEnumerable<TypeDefinition> GetMemberDependencies<TSymbol>(
            TypeDefinition typeDefinition
        )
            where TSymbol : ISymbol
        {
            return typeDefinition
                .Symbol.GetMembers()
                .OfType<TSymbol>()
                .Select(member =>
                    member switch
                    {
                        IFieldSymbol field => field.Type,
                        IPropertySymbol property => property.Type,
                        _ => throw new InvalidCastException(
                            $"{nameof(TSymbol)} must be {nameof(IFieldSymbol)} or {nameof(IPropertySymbol)}"
                        ),
                    }
                )
                .OfType<INamedTypeSymbol>()
                .Where(type => !type.Equals(typeDefinition))
                .Where(t1 =>
                    typeDefinition
                        .GetAllTypesFromProject()
                        .Any(t2 => t2.Symbol.Equals(t1, SymbolEqualityComparer.Default))
                )
                .Select(type => new TypeDefinition(typeDefinition.Project, type));
        }

        private static IEnumerable<TypeDefinition> GetFieldsDependencies(
            TypeDefinition typeDefinition
        )
        {
            return GetMemberDependencies<IFieldSymbol>(typeDefinition);
        }

        private static IEnumerable<TypeDefinition> GetPropertiesDependencies(
            TypeDefinition typeDefinition
        )
        {
            return GetMemberDependencies<IPropertySymbol>(typeDefinition);
        }

        private static IEnumerable<TypeDefinition> GetMethodsDependencies(
            TypeDefinition typeDefinition
        )
        {
            return typeDefinition
                .Symbol.GetMembers()
                .OfType<IMethodSymbol>()
                .Where(method => !method.IsImplicitlyDeclared)
                .SelectMany(method => method.GetDependencies(typeDefinition));
        }
    }
}
