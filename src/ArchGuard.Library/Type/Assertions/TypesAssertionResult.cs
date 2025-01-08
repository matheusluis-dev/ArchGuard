namespace ArchGuard.Library.Type.Assertions
{
    using System.Collections.Generic;
    using System.Linq;

    public sealed class TypesAssertionResult
    {
        public bool IsSuccessful => !NonCompliantTypes.Any();
        public IEnumerable<TypeSpec> TypesFiltered { get; }
        public IEnumerable<TypeSpec> CompliantTypes { get; }
        public IEnumerable<TypeSpec> NonCompliantTypes => TypesFiltered.Except(CompliantTypes);

        internal TypesAssertionResult(
            IEnumerable<TypeSpec> typesFiltered,
            IEnumerable<TypeSpec> typesAsserted
        )
        {
            TypesFiltered = typesFiltered;
            CompliantTypes = typesAsserted;
        }
    }
}
