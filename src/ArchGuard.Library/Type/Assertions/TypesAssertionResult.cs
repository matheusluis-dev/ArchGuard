namespace ArchGuard.Library.Type.Assertions
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CodeAnalysis;

    public sealed class TypesAssertionResult
    {
        public bool IsSuccessful => !NonCompliantTypes.Any();
        public IEnumerable<Type_> TypesFiltered { get; }
        public IEnumerable<Type_> CompliantTypes { get; }
        public IEnumerable<Type_> NonCompliantTypes => TypesFiltered.Except(CompliantTypes);

        internal TypesAssertionResult(
            IEnumerable<Type_> typesFiltered,
            IEnumerable<Type_> typesAsserted
        )
        {
            TypesFiltered = typesFiltered;
            CompliantTypes = typesAsserted;
        }
    }
}
