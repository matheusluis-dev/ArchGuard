namespace ArchGuard.Cached
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using ArchGuard.Core.Type.Models;
    using Microsoft.CodeAnalysis;

    public sealed class DependencyFinder
    {
        private static readonly ConcurrentDictionary<
            TypeDefinition,
            IEnumerable<TypeDefinition>
        > _cache = new();

        private static readonly ConcurrentDictionary<TypeDefinition, SemaphoreSlim> _locks = new();

        public IEnumerable<TypeDefinition> GetDependencies(TypeDefinition type)
        {
            ArgumentNullException.ThrowIfNull(type);

            var semaphore = _locks.GetOrAdd(type, _ => new SemaphoreSlim(1, 1));
            semaphore.Wait();

            try
            {
                if (_cache.TryGetValue(type, out var result))
                    return result;

                var dependencies = new HashSet<TypeDefinition>();

                dependencies.UnionWith(GetFieldsDependencies(type));
                dependencies.UnionWith(GetPropertiesDependencies(type));
                dependencies.UnionWith(GetMethodsDependencies(type));

                foreach (var dependency in new HashSet<TypeDefinition>(dependencies))
                    dependencies.UnionWith(GetDependencies(dependency));

                _cache.TryAdd(type, dependencies);

                return dependencies;
            }
            finally
            {
                semaphore.Release();
                _locks.TryRemove(type, out _);
            }

            // TODO: find a way to fix it, it gets primitive types and loops eternally
            //.Where(t1 =>
            //    type
            //        .GetAllTypesFromProject()
            //        .Any(t2 => t2.Symbol.Equals(t1, SymbolEqualityComparer.Default))
            //)
            IEnumerable<TypeDefinition> GetFieldsDependencies(TypeDefinition type)
            {
                return type.GetFields()
                    .Select(field => field.Type)
                    .Where(type => !type.Equals(type));
            }

            IEnumerable<TypeDefinition> GetPropertiesDependencies(TypeDefinition type)
            {
                return type.GetProperties()
                    .Select(field => field.Type)
                    .Where(type => !type.Equals(type));
            }

            IEnumerable<TypeDefinition> GetMethodsDependencies(TypeDefinition type)
            {
                return type.GetMethods().SelectMany(method => method.GetDependencies());
            }
        }
    }
}
