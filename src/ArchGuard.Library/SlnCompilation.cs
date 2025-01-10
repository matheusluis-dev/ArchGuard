namespace ArchGuard.Library
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CodeAnalysis;

    public sealed class SlnCompilation
    {
        public Solution Solution { get; set; }
        public IEnumerable<(Project, Compilation)> Compilations { get; set; }
        public IDictionary<Project, IEnumerable<INamedTypeSymbol>> Types { get; set; }

        public IEnumerable<INamedTypeSymbol> AllTypes => Types.Values.SelectMany(types => types);
    }
}
