namespace ArchGuard.Library.Type.Contexts
{
    using System;
    using System.Collections.Generic;

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
