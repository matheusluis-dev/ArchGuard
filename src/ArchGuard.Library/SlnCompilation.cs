namespace ArchGuard.Library
{
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis;

    public sealed class SlnCompilation
    {
        public Solution Solution { get; set; }
        public IEnumerable<Type_> Types { get; set; }
    }
}
