namespace ArchGuard
{
    using ArchGuard.Core.Contexts;

    public sealed partial class TypeFilter : ITypeFilterEntryPoint, ITypeFilterRule, ITypeFilterSequence, IVerify
    {
        private readonly TypeFilterContext _context;

        private readonly Lazy<StartTypeAssertionCallback> _startAssertionCallback;
        private readonly Lazy<StartMethodFilterCallback> _startMethodFilterCallback;
        private readonly Lazy<StartFieldFilterCallback> _startFieldFilterCallback;
        private readonly Lazy<StartPropertyFilterCallback> _startPropertyFilterCallback;
        private readonly Lazy<StartSliceFilterCallback> _startSliceFilterCallback;

        internal TypeFilter(
            TypeFilterContext context,
            Lazy<StartTypeAssertionCallback> startAssertionCallback,
            Lazy<StartMethodFilterCallback> startMethodFilterCallback,
            Lazy<StartFieldFilterCallback> startFieldFilterCallback,
            Lazy<StartPropertyFilterCallback> startPropertyFilterCallback,
            Lazy<StartSliceFilterCallback> startSliceFilterCallback
        )
        {
            _context = context;

            _startAssertionCallback = startAssertionCallback;
            _startMethodFilterCallback = startMethodFilterCallback;
            _startFieldFilterCallback = startFieldFilterCallback;
            _startPropertyFilterCallback = startPropertyFilterCallback;
            _startSliceFilterCallback = startSliceFilterCallback;
        }

        internal ITypeFilterEntryPoint Start()
        {
            return this;
        }

        public IVerify Verify()
        {
            return this;
        }

        public ISliceFilterRule Slice => _startSliceFilterCallback.Value.Invoke();

        public IMethodFilterEntryPoint Methods => _startMethodFilterCallback.Value.Invoke();

        public IFieldFilterEntryPoint Fields => _startFieldFilterCallback.Value.Invoke();

        public ITypeAssertionRule Should => _startAssertionCallback.Value.Invoke();

        public IPropertyFilterEntryPoint Properties => _startPropertyFilterCallback.Value.Invoke();
    }
}
