namespace ArchGuard
{
    using ArchGuard.Core.Type.Contexts;

    public sealed partial class TypeFilter
        : ITypeFilterEntryPoint,
            ITypeFilterRule,
            ITypeFilterSequence,
            IVerify
    {
        private readonly TypeFilterContext _context;

        private readonly StartTypeAssertionCallback _startAssertionCallback;
        private readonly StartMethodFilterCallback _startMethodFilterCallback;
        private readonly StartFieldFilterCallback _startFieldFilterCallback;

        internal TypeFilter(
            TypeFilterContext context,
            StartTypeAssertionCallback startAssertionCallback,
            StartMethodFilterCallback startMethodFilterCallback,
            StartFieldFilterCallback startFieldFilterCallback
        )
        {
            _context = context;

            _startAssertionCallback = startAssertionCallback;
            _startMethodFilterCallback = startMethodFilterCallback;
            _startFieldFilterCallback = startFieldFilterCallback;
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

        public ITypeAssertionRule Should => _startAssertionCallback.Invoke();

        public IFieldFilterEntryPoint Fields => _startFieldFilterCallback.Invoke();
    }
}
