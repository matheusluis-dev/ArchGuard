namespace ArchGuard.Core.Method.Models
{
    using System.Collections.Generic;

    public sealed class MethodAssertionResult
    {
        public bool IsSuccessful => !NonCompliantMethods.Any();
        public IEnumerable<MethodDefinition> MethodsFiltered { get; }
        public IEnumerable<MethodDefinition> CompliantMethods { get; }
        public IEnumerable<MethodDefinition> NonCompliantMethods =>
            MethodsFiltered.Except(CompliantMethods);

        internal MethodAssertionResult(
            IEnumerable<MethodDefinition> methodsFiltered,
            IEnumerable<MethodDefinition> methodsAsserted
        )
        {
            MethodsFiltered = methodsFiltered;
            CompliantMethods = methodsAsserted;
        }
    }
}
