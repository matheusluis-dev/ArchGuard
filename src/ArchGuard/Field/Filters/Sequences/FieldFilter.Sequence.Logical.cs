namespace ArchGuard
{
    public sealed partial class FieldFilter
    {
        public IFieldFilterRule And => this;
        public IFieldFilterRule Or => OrInternal();

        internal IFieldFilterRule OrInternal()
        {
            _context.Or();
            return this;
        }
    }
}
