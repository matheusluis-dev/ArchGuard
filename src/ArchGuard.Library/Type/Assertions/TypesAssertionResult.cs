namespace ArchGuard.Library.Type.Assertions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class TypesAssertionResult
    {
        public bool IsSuccessful => !NonCompliantTypes.Any();
        public IEnumerable<Type> TypesFiltered { get; }
        public IEnumerable<Type> CompliantTypes { get; }
        public IEnumerable<Type> NonCompliantTypes => TypesFiltered.Except(CompliantTypes);

        internal TypesAssertionResult(
            IEnumerable<Type> typesFiltered,
            IEnumerable<Type> typesAsserted
        )
        {
            TypesFiltered = typesFiltered;
            CompliantTypes = typesAsserted;
        }
    }
}
