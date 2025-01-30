namespace ArchGuard.Contexts
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Kernel.Models;

    public sealed class MethodFilterContext : ContextBase<MethodDefinition>
    {
        public MethodFilterContext(IEnumerable<MethodDefinition> methods)
            : base(methods) { }

        public IEnumerable<MethodDefinition> GetMethods()
        {
            return GetElements();
        }

        public IEnumerable<MethodDefinition> GetMethods(StringComparison comparison)
        {
            return GetElements(comparison);
        }
    }
}
