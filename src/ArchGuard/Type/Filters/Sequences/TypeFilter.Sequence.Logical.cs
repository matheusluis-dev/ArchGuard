namespace ArchGuard
{
    public sealed partial class TypeFilter
    {
        public ITypeFilterRule And => this;

        public ITypeFilterRule Or => OrInternal();

        internal ITypeFilterRule OrInternal()
        {
            _context.Or();
            return this;
        }
    }
}
