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

        private readonly List<ProjectDefinition> _projects = [];
        public IEnumerable<ProjectDefinition> Projects { get; set; }
        private readonly List<TypeDefinition> _allTypes = [];
        public IReadOnlyList<TypeDefinition> AllTypes
        {
            get
            {
                if (_allTypes.Count > 0)
                    return _allTypes;

                _allTypes.AddRange(Projects.SelectMany(project => project.AllTypes));

                return _allTypes;
            }
        }

        private readonly List<TypeDefinition> _typesFromProjects = [];
        public IReadOnlyList<TypeDefinition> TypesFromProjects
        {
            get
            {
                if (_typesFromProjects.Count > 0)
                    return _typesFromProjects;

                _typesFromProjects.AddRange(
                    Projects.SelectMany(project => project.TypesFromProject)
                );

                return _typesFromProjects;
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
