namespace ArchGuard
{
    using ArchGuard.Contexts;
    using static ArchGuard.RulesContext;

    public sealed partial class TypeFilter
        : ITypeFilterEntryPoint,
            ITypeFilterRule,
            ITypeFilterSequence,
            IVerify
    {
        private readonly TypeFilterContext _context;

        private readonly StartTypeAssertionCallback _startAssertionCallback;
        private readonly StartMethodFilterCallback _startMethodFilterCallback;

        internal TypeFilter(
            TypeFilterContext context,
            StartTypeAssertionCallback startAssertionCallback,
            StartMethodFilterCallback startMethodFilterCallback
        )
        {
            _context = context;

            _startAssertionCallback = startAssertionCallback;
            _startMethodFilterCallback = startMethodFilterCallback;
        }

        internal ITypeFilterEntryPoint Start()
        {
            return this;
        }

        public IVerify Verify()
        {
            return this;
        }

        public IMethodFilterEntryPoint Methods => _startMethodFilterCallback.Invoke();
    }
}
