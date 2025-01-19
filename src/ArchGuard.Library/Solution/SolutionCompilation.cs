namespace ArchGuard.Library.Solution
{
    using System.Collections.Generic;
    using ArchGuard.Library.Type;
    using Microsoft.CodeAnalysis;

    public sealed class SolutionCompilation
    {
        public Solution Solution { get; set; }
        public IEnumerable<TypeDefinition> Types { get; set; }
    }
}
