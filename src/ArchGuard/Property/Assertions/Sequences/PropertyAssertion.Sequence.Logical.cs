namespace ArchGuard
{
    public sealed partial class PropertyAssertion
    {
        public IPropertyAssertionRule And => this;
        public IPropertyAssertionRule Or => OrInternal();

        internal IPropertyAssertionRule OrInternal()
        {
            _context.Or();
            return this;
        }
    }
}
