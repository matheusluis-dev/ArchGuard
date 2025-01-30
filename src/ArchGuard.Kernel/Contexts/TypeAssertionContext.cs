namespace ArchGuard.Contexts
{
    using System;
    using ArchGuard;
    using ArchGuard.Kernel.Models;

    public sealed class TypeAssertionContext : ContextBase<TypeDefinition>
    {
        public TypeAssertionContext(ContextBase<TypeDefinition> filterContext)
            : base(filterContext) { }

        public TypeAssertionResult GetResult()
        {
            return GetResult(Default.StringComparison);
        }

        public TypeAssertionResult GetResult(StringComparison comparison)
        {
            var typesFiltered = GetElementsWithoutApplyPredicates(comparison);
            var typesAsserted = GetElements(comparison);

            return new TypeAssertionResult(typesFiltered, typesAsserted);
        }
    }
}
