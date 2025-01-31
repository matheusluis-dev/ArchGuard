namespace ArchGuard
{
    using System.Collections.Generic;
    using ArchGuard.Contexts;
    using static ArchGuard.RulesContext;

    public sealed partial class MethodFilter
        : IMethodFilterEntryPoint,
            IMethodFilterRule,
            IMethodFilterSequence
    {
        private readonly MethodFilterContext _context;
        private readonly StartMethodAssertionCallback _startMethodAssertionCallback;

        internal MethodFilter(
            MethodFilterContext context,
            StartMethodAssertionCallback startMethodAssertionCallback
        )
        {
            _context = context;
            _startMethodAssertionCallback = startMethodAssertionCallback;
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

        public IMethodAssertionRule Should => _startMethodAssertionCallback.Invoke();
    }
}
