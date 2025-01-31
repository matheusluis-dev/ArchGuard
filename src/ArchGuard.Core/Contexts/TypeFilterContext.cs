namespace ArchGuard.Contexts
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Core.Models;

    public sealed class TypeFilterContext : ContextBase<TypeDefinition>
    {
        public TypeFilterContext(IEnumerable<TypeDefinition> types)
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
