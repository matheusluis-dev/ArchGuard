namespace ArchGuard.Roslyn.Type.Assertions
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CodeAnalysis;

    public sealed class TypesAssertionResult
    {
        public bool IsSuccessful => !NonCompliantTypes.Any();
        public IEnumerable<INamedTypeSymbol> TypesFiltered { get; }
        public IEnumerable<INamedTypeSymbol> CompliantTypes { get; }
        public IEnumerable<INamedTypeSymbol> NonCompliantTypes =>
            TypesFiltered.Except(CompliantTypes);

        internal TypesAssertionResult(
            IEnumerable<INamedTypeSymbol> typesFiltered,
            IEnumerable<INamedTypeSymbol> typesAsserted
        )
        {
            TypesFiltered = typesFiltered;
            CompliantTypes = typesAsserted;
        }
    }
}
