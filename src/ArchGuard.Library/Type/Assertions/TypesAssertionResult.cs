namespace ArchGuard.Library.Type.Assertions
{
    using System.Collections.Generic;
    using System.Linq;

    public sealed class TypesAssertionResult
    {
        public bool IsSuccessful => !NonCompliantTypes.Any();
        public IEnumerable<TypeSpecRoslyn> TypesFiltered { get; }
        public IEnumerable<TypeSpecRoslyn> CompliantTypes { get; }
        public IEnumerable<TypeSpecRoslyn> NonCompliantTypes =>
            TypesFiltered.Except(CompliantTypes);

        internal TypesAssertionResult(
            IEnumerable<TypeSpecRoslyn> typesFiltered,
            IEnumerable<TypeSpecRoslyn> typesAsserted
        )
        {
            TypesFiltered = typesFiltered;
            CompliantTypes = typesAsserted;
        }
    }
}
