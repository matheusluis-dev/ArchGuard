namespace ArchGuard.Core.Slice.Models
{
    using ArchGuard.Core.Type.Models;
    using Microsoft.CodeAnalysis;

    public sealed class SliceDefinition
    {
        internal SolutionDefinition Solution { get; init; }
        internal ProjectDefinition Project { get; init; }

        internal string Namespace { get; init; }

        internal IEnumerable<TypeDefinition> Types =>
            Solution.AllTypes.Where(type =>
                type.Namespace.StartsWith(Namespace, StringComparison.Ordinal)
            );

        internal IDictionary<TypeDefinition, IEnumerable<TypeDefinition>> DependenciesForEachType
        {
            get
            {
                var dictionary = new Dictionary<TypeDefinition, IEnumerable<TypeDefinition>>();

                foreach (var type in Types)
                {
                    dictionary.Add(type, type.GetDependencies());
                }

                return dictionary;
            }
        }

        internal SliceDefinition(
            SolutionDefinition solution,
            ProjectDefinition project,
            string @namespace
        )
        {
            Solution = solution;
            Project = project;
            Namespace = @namespace;
        }
    }
}
