namespace ArchGuard.Cached
{
    using System;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using ArchGuard.Core;
    using ArchGuard.Core.Models;
    using ArchGuard.Core.Results;
    using ArchGuard.Exceptions;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.MSBuild;

    public sealed class SolutionCompiler
    {
        private static readonly Lock _lock = new Lock();

        private static readonly ConcurrentDictionary<
            SolutionSearchParameters,
            SolutionDefinition
        > _cache = new();

        private readonly DependencyFinder _dependencyFinder;
        private readonly TypesLoader _typesLoader;

        public SolutionCompiler(DependencyFinder dependencyFinder, TypesLoader typesLoader)
        {
            _dependencyFinder = dependencyFinder;
            _typesLoader = typesLoader;
        }

        private static Result<FileInfo> ResolveSlnPath(string path)
        {
            if (File.Exists(path))
                return Result<FileInfo>.Success(new FileInfo(path));

            return FindFileHelper.GetFileInSolution(path);
        }

        public SolutionDefinition Compile(SolutionSearchParameters parameters)
        {
            ArgumentNullException.ThrowIfNull(_dependencyFinder);

            lock (_lock)
            {
                if (_cache.TryGetValue(parameters, out var sln))
                    return sln;

                using var workspace = MSBuildWorkspace.Create();

                var resultSlnPath = ResolveSlnPath(parameters.SolutionPath);

                if (!resultSlnPath.IsSuccess)
                    throw new SolutionNotFoundException(resultSlnPath.Error!);

                var solution = workspace.OpenSolutionAsync(resultSlnPath.Value.FullName).Result;

                var projects = solution
                    .Projects.Where(p =>
                        p.Name.Equals(parameters.ProjectName, StringComparison.Ordinal)
                        && (
                            string.IsNullOrWhiteSpace(parameters.Preprocessor)
                            || p.ParseOptions?.PreprocessorSymbolNames.Contains(
                                parameters.Preprocessor,
                                StringComparer.OrdinalIgnoreCase
                            ) == true
                        )
                    )
                    .Select(project => new ProjectDefinition(
                        _dependencyFinder,
                        _typesLoader,
                        project
                    ));

                if (projects?.Any() != true)
                {
                    throw new ProjectNotFoundException(
                        Error.Prj01ProjectNotFound(parameters.ProjectName)
                    );
                }

                var solutionDefinition = new SolutionDefinition(
                    _dependencyFinder,
                    _typesLoader,
                    solution
                );

                _cache.TryAdd(parameters, solutionDefinition);

                return solutionDefinition;
            }
        }
    }
}
