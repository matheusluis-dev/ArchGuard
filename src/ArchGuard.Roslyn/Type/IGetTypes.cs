namespace ArchGuard.Roslyn.Type
{
    using System;
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis;

    public interface IGetTypes
    {
        IEnumerable<INamedTypeSymbol> GetTypes();
        IEnumerable<INamedTypeSymbol> GetTypes(StringComparison comparison);
    }
}
