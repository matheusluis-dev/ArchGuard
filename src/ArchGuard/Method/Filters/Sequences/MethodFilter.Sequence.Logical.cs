namespace ArchGuard
{
    public sealed partial class MethodFilter
    {
        public IMethodFilterRule And => this;
        public IMethodFilterRule Or => OrInternal();

        internal IMethodFilterRule OrInternal()
        {
            _context.Or();
            return this;
        }
    }
}
