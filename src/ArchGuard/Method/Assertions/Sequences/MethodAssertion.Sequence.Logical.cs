namespace ArchGuard
{
    public sealed partial class MethodAssertion
    {
        public IMethodAssertionRule And => this;
        public IMethodAssertionRule Or => OrInternal();

        internal IMethodAssertionRule OrInternal()
        {
            _context.Or();
            return this;
        }
    }
}
