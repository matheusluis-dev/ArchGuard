namespace ArchGuard
{
    using System.Collections.Generic;
    using ArchGuard.Core.Contexts;
    using ArchGuard.Core.Method.Models;

    public sealed partial class MethodFilter : IMethodFilterEntryPoint, IMethodFilterRule, IMethodFilterSequence
    {
        private readonly MemberFilterContext<MethodDefinition> _context;
        private readonly StartMethodAssertionCallback _startMethodAssertionCallback;

        internal MethodFilter(
            MemberFilterContext<MethodDefinition> context,
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
            return _context.GetElements(comparison);
        }

        public IMethodAssertionRule Should => _startMethodAssertionCallback.Invoke();
    }
}
