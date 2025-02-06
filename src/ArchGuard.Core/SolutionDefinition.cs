namespace ArchGuard.Core
{
    using System.Diagnostics;
    using ArchGuard.Cached;
    using ArchGuard.Core.Type.Models;
    using Microsoft.CodeAnalysis;

    [DebuggerDisplay("{Path}")]
    public sealed class SolutionDefinition
    {
        private readonly DependencyFinder _dependencyFinder;
        private readonly TypesLoader _typesLoader;
        private readonly Solution _solution;

        public string Path => _solution.FilePath ?? string.Empty;

        public IEnumerable<ProjectDefinition> Projects =>
            _solution.Projects.Select(project => new ProjectDefinition(
                _dependencyFinder,
                _typesLoader,
                project
            ));

        private readonly List<TypeDefinition> _types = [];
        public IReadOnlyList<TypeDefinition> Types
        {
            get
            {
                if (_types.Count > 0)
                    return _types;

                _types.AddRange(Projects.SelectMany(project => project.Types));

                return _types;
            }
        }

        public SolutionDefinition(
            DependencyFinder dependencyFinder,
            TypesLoader typesLoader,
            Solution solution
        )
        {
            _dependencyFinder = dependencyFinder;
            _typesLoader = typesLoader;
            _solution = solution;
        }
    }
}
