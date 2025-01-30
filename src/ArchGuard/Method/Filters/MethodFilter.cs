namespace ArchGuard
{
    using System.Collections.Generic;
    using ArchGuard.Contexts;
    using ArchGuard.Kernel.Models;

    public sealed partial class MethodFilter
        : IMethodFilterEntryPoint,
            IMethodFilterRule,
            IMethodFilterSequence
    {
        private readonly MethodFilterContext _context;

        internal MethodFilter(MethodFilterContext context)
        {
            _context = context;
        }

        internal IMethodFilterEntryPoint Start()
        {
            return this;
        }

        public IEnumerable<MethodDefinition> GetMethods()
        {
            return GetMethods(Default.StringComparison);
        }

        public IEnumerable<MethodDefinition> GetMethods(StringComparison comparison)
        {
            return _context.GetMethods(comparison);
        }
    }
}
