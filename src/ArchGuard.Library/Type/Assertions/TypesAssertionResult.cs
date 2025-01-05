namespace ArchGuard.Library.Type.Assertions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class TypesAssertionResult
    {
        public bool IsSuccessful => !NonCompliantTypes.Any();
        public IEnumerable<Type> TypesFiltered { get; set; }
        public IEnumerable<Type> NonCompliantTypes { get; set; }

        internal TypesAssertionResult(
            IEnumerable<Type> typesFiltered,
            IEnumerable<Type> typesAsserted
        )
        {
            TypesFiltered = typesFiltered;
            NonCompliantTypes = typesFiltered.Except(typesAsserted);
        }
    }
}
