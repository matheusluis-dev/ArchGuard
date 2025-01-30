namespace ArchGuard.Contexts
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Kernel.Models;

    public sealed class TypeDefinitionFilterContext : ContextBase<TypeDefinition>
    {
        public TypeDefinitionFilterContext(IEnumerable<TypeDefinition> types)
            : base(types) { }

        public IEnumerable<TypeDefinition> GetTypes()
        {
            return GetElements();
        }

        public IEnumerable<TypeDefinition> GetTypes(StringComparison comparison)
        {
            return GetElements(comparison);
        }
    }
}
