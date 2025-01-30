namespace ArchGuard
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CodeAnalysis;

    public sealed class TypesAssertionResult
    {
        public bool IsSuccessful => !NonCompliantTypes.Any();
        public IEnumerable<TypeDefinition> TypesFiltered { get; }
        public IEnumerable<TypeDefinition> CompliantTypes { get; }
        public IEnumerable<TypeDefinition> NonCompliantTypes =>
            TypesFiltered.Except(CompliantTypes);

        internal TypesAssertionResult(
            IEnumerable<TypeDefinition> typesFiltered,
            IEnumerable<TypeDefinition> typesAsserted
        )
        {
            TypesFiltered = typesFiltered;
            CompliantTypes = typesAsserted;
        }
    }
}
