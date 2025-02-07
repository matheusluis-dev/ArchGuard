namespace ArchGuard
{
    public sealed partial class PropertyFilter
    {
        public IPropertyFilterRule And => this;
        public IPropertyFilterRule Or => OrInternal();

        internal IPropertyFilterRule OrInternal()
        {
            _context.Or();
            return this;
        }
    }
}
