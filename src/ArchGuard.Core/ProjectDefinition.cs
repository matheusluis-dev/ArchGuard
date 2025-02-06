namespace ArchGuard.Core
{
    using System.Diagnostics;
    using ArchGuard.Cached;
    using ArchGuard.Core.Type.Models;
    using Microsoft.CodeAnalysis;

    [DebuggerDisplay("{Name}")]
    public sealed class ProjectDefinition
    {
        private readonly DependencyFinder _dependencyFinder;
        private readonly TypesLoader _typesLoader;
        private readonly Project _project;

        internal string Name => _project.Name;

        internal string DefaultNamespace => _project.DefaultNamespace!;

        internal Compilation Compilation => _project.GetCompilationAsync().Result!;

        private readonly List<TypeDefinition> _types = [];
        internal IReadOnlyList<TypeDefinition> Types
        {
            get
            {
                if (_types.Count > 0)
                    return _types;

                _types.AddRange(
                    _typesLoader
                        .GetAllTypeMembers(Compilation.GlobalNamespace, Compilation.Assembly)
                        .Select(symbol => new TypeDefinition(_dependencyFinder, this, symbol))
                );

                return _types;
            }
        }

        internal ProjectDefinition(
            DependencyFinder dependencyFinder,
            TypesLoader typesLoader,
            Project project
        )
        {
            _dependencyFinder = dependencyFinder;
            _typesLoader = typesLoader;
            _project = project;
        }
    }
}
