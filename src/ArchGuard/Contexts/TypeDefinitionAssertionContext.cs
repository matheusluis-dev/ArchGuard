namespace ArchGuard.Contexts
{
    using System;
    using ArchGuard;
    using ArchGuard.Type;
    using ArchGuard.Type.Assertions.Models;

    internal sealed class TypeDefinitionAssertionContext : ContextBase<TypeDefinition>
    {
        public TypeDefinitionAssertionContext(ContextBase<TypeDefinition> filterContext)
            : base(filterContext) { }

        internal TypesAssertionResult GetResult()
        {
            return GetResult(Default.StringComparison);
        }

        internal TypesAssertionResult GetResult(StringComparison comparison)
        {
            var typesFiltered = GetElementsWithoutFilter(comparison);
            var typesAsserted = GetElements(comparison);

            return new TypesAssertionResult(typesFiltered, typesAsserted);
        }
    }
}
