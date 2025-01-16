namespace ArchGuard.Library.Cached
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading;
    using Microsoft.CodeAnalysis;

    internal static class TypesSearchCached
    {
        private static readonly Lock _lock = new Lock();

        private static readonly ConcurrentDictionary<
            (INamespaceSymbol, IAssemblySymbol),
            IEnumerable<INamedTypeSymbol>
        > _cache = new();

        internal static IEnumerable<INamedTypeSymbol> GetAllTypeMembers(
            INamespaceSymbol namespaceSymbol,
            IAssemblySymbol assemblySymbol
        )
        {
            lock (_lock)
            {
                if (_cache.TryGetValue((namespaceSymbol, assemblySymbol), out var result))
                    return result;

                var typeMembers = new List<INamedTypeSymbol>();

                foreach (var typeMember in namespaceSymbol.GetTypeMembers())
                {
                    if (typeMember.ContainingAssembly.Equals(assemblySymbol))
                    {
                        typeMembers.Add(typeMember);
                        typeMembers.AddRange(GetAllTypeMembers(typeMember, assemblySymbol));
                    }
                }

                foreach (var nestedNamespace in namespaceSymbol.GetNamespaceMembers())
                {
                    typeMembers.AddRange(GetAllTypeMembers(nestedNamespace, assemblySymbol));
                }

                _cache.TryAdd((namespaceSymbol, assemblySymbol), typeMembers);

                return typeMembers;
            }
        }

        private static IEnumerable<INamedTypeSymbol> GetAllTypeMembers(
            INamedTypeSymbol typeSymbol,
            IAssemblySymbol assemblySymbol
        )
        {
            var typeMembers = new List<INamedTypeSymbol>();

            foreach (var nestedType in typeSymbol.GetTypeMembers())
            {
                if (nestedType.ContainingAssembly.Equals(assemblySymbol))
                {
                    typeMembers.Add(nestedType);
                    typeMembers.AddRange(GetAllTypeMembers(nestedType, assemblySymbol));
                }
            }

            return typeMembers;
        }
    }
}
