namespace ArchGuard
{
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Core.Models;
    using Microsoft.CodeAnalysis;

    public sealed class TypeAssertionResult
    {
        public bool IsSuccessful => !NonCompliantTypes.Any();
        public IEnumerable<TypeDefinition> TypesFiltered { get; }
        public IEnumerable<TypeDefinition> CompliantTypes { get; }
        public IEnumerable<TypeDefinition> NonCompliantTypes =>
            TypesFiltered.Except(CompliantTypes);

        internal TypeAssertionResult(
            IEnumerable<TypeDefinition> typesFiltered,
            IEnumerable<TypeDefinition> typesAsserted
        )
        {
            TypesFiltered = typesFiltered;
            CompliantTypes = typesAsserted;
        }
    }
}
