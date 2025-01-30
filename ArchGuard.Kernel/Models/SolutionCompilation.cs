namespace ArchGuard
{
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis;

    public sealed class SolutionCompilation
    {
        public Solution Solution { get; set; }
        public IEnumerable<TypeDefinition> Types { get; set; }
    }
}
