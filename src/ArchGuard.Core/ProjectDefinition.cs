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

        private readonly SolutionDefinition _solution;
        private readonly Project _project;

        internal string Name => _project.Name;

        internal string DefaultNamespace => _project.DefaultNamespace!;

        internal Compilation Compilation => _project.GetCompilationAsync().Result!;

        private readonly List<TypeDefinition> _typesFromProject = [];
        internal IReadOnlyList<TypeDefinition> TypesFromProject
        {
            get
            {
                if (_typesFromProject.Count > 0)
                    return _typesFromProject;

                _typesFromProject.AddRange(
                    _typesLoader
                        .GetFromProject(Compilation.GlobalNamespace, Compilation.Assembly)
                        .Select(symbol => new TypeDefinition(_dependencyFinder, _solution, this, symbol))
                );

                return _typesFromProject;
            }
        }

        private readonly List<TypeDefinition> _allTypes = [];
        internal IReadOnlyList<TypeDefinition> AllTypes
        {
            get
            {
                if (_allTypes.Count > 0)
                    return _allTypes;

                _allTypes.AddRange(
                    _typesLoader
                        .GetFromProject(Compilation.GlobalNamespace, null)
                        .Select(symbol => new TypeDefinition(_dependencyFinder, _solution, this, symbol))
                );

                return _allTypes;
            }
        }

        internal ProjectDefinition(
            DependencyFinder dependencyFinder,
            TypesLoader typesLoader,
            SolutionDefinition solution,
            Project project
        )
        {
            _dependencyFinder = dependencyFinder;
            _typesLoader = typesLoader;
            _solution = solution;
            _project = project;
        }
    }
}
