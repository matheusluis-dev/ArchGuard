namespace ArchGuard
{
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis;

    public sealed class SolutionCompilation
    {
        public required Solution Solution { get; set; }
        public required IEnumerable<TypeDefinition> Types { get; set; }

        public IEnumerable<MethodDefinition> Methods => Types.SelectMany(type => type.GetMethods());
    }
}
