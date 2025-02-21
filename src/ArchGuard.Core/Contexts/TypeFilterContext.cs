namespace ArchGuard.Core.Contexts
{
    using System.Collections.Generic;
    using ArchGuard.Core.Type.Models;

    public sealed class TypeFilterContext : ContextEngine<TypeDefinition>
    {
        private readonly IEnumerable<TypeDefinition> _types;

        public TypeFilterContext(IEnumerable<TypeDefinition> types)
        {
            _types = types;
        }

        protected override IEnumerable<TypeDefinition> ElementsToFilter(StringComparison comparison)
        {
            return _types;
        }
    }
}
