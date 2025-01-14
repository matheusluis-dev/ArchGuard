namespace ArchGuard.Library
{
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis;

    public sealed class SlnCompilation
    {
        public Solution Solution { get; set; }
        public IEnumerable<TypeDefinition> Types { get; set; }
    }
}
