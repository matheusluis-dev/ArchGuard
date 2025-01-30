namespace ArchGuard.Contexts
{
    using System;
    using ArchGuard;
    using ArchGuard.Kernel.Models;

    public sealed class TypeDefinitionAssertionContext : ContextBase<TypeDefinition>
    {
        public TypeDefinitionAssertionContext(ContextBase<TypeDefinition> filterContext)
            : base(filterContext) { }

        public TypesAssertionResult GetResult()
        {
            return GetResult(Default.StringComparison);
        }

        public TypesAssertionResult GetResult(StringComparison comparison)
        {
            var typesFiltered = GetElementsWithoutFilter(comparison);
            var typesAsserted = GetElements(comparison);

            return new TypesAssertionResult(typesFiltered, typesAsserted);
        }
    }
}
