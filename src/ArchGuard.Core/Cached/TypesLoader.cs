namespace ArchGuard.Cached
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Microsoft.CodeAnalysis;

    public sealed class TypesLoader
    {
        private static readonly Lock _lock = new Lock();

        private static readonly ConcurrentDictionary<
            (INamespaceSymbol, IAssemblySymbol?),
            IEnumerable<INamedTypeSymbol>
        > _cache = new();

        public IEnumerable<INamedTypeSymbol> GetFromProject(
            INamespaceSymbol namespaceSymbol,
            IAssemblySymbol? assemblySymbol = null
        )
        {
            lock (_lock)
            {
                if (_cache.TryGetValue((namespaceSymbol, assemblySymbol), out var result))
                    return result;

                var typeMembers = new HashSet<INamedTypeSymbol>(SymbolEqualityComparer.Default);
                foreach (
                    var typeMember in namespaceSymbol
                        .GetTypeMembers()
                        .Where(typeMember =>
                            assemblySymbol is null
                            || typeMember.ContainingAssembly.Equals(assemblySymbol, SymbolEqualityComparer.Default)
                        )
                )
                {
                    typeMembers.Add(typeMember);
                    typeMembers.UnionWith(GetAllTypeMembers(typeMember, assemblySymbol!));
                }

                foreach (var nestedNamespace in namespaceSymbol.GetNamespaceMembers())
                {
                    typeMembers.UnionWith(GetFromProject(nestedNamespace, assemblySymbol));
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
            foreach (
                var nestedType in typeSymbol
                    .GetTypeMembers()
                    .Where(nestedType =>
                        nestedType.ContainingAssembly.Equals(assemblySymbol, SymbolEqualityComparer.Default)
                    )
            )
            {
                typeMembers.Add(nestedType);
                typeMembers.AddRange(GetAllTypeMembers(nestedType, assemblySymbol));
            }

            return typeMembers;
        }
    }
}
