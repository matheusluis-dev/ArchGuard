namespace ArchGuard.Roslyn
{
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis;

    public sealed class SlnCompilations
    {
        public Solution Solution { get; }
        public IEnumerable<Compilation> Compilations { get; }
        public IDictionary<Project, INamedTypeSymbol> Types { get; }

        public SlnCompilations(SolutionSearchParameters parameters)
        {

        }
    }
}
