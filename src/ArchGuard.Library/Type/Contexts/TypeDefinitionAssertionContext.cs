namespace ArchGuard.Library.Type.Contexts
{
    using System;
    using ArchGuard.Library.Type.Assertions;

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
