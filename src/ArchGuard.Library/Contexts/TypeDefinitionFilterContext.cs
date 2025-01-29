namespace ArchGuard.Contexts
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Type;

    internal sealed class TypeDefinitionFilterContext : ContextBase<TypeDefinition>
    {
        internal TypeDefinitionFilterContext(IEnumerable<TypeDefinition> types)
            : base(types) { }

        internal IEnumerable<TypeDefinition> GetTypes()
        {
            return GetElements();
        }

        internal IEnumerable<TypeDefinition> GetTypes(StringComparison comparison)
        {
            return GetElements(comparison);
        }
    }
}
