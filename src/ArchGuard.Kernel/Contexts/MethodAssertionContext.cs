namespace ArchGuard.Contexts
{
    using System;
    using ArchGuard;
    using ArchGuard.Kernel.Models;

    public sealed class MethodAssertionContext : ContextBase<MethodDefinition>
    {
        public MethodAssertionContext(ContextBase<MethodDefinition> filterContext)
            : base(filterContext) { }

        public MethodAssertionResult GetResult()
        {
            return GetResult(Default.StringComparison);
        }

        public MethodAssertionResult GetResult(StringComparison comparison)
        {
            var methodsFiltered = GetElementsWithoutApplyPredicates(comparison);
            var methodsAsserted = GetElements(comparison);

            return new MethodAssertionResult(methodsFiltered, methodsAsserted);
        }
    }
}
