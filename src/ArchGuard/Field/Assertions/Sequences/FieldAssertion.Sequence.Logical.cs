namespace ArchGuard
{
    public sealed partial class FieldAssertion
    {
        public IFieldAssertionRule And => this;
        public IFieldAssertionRule Or => OrInternal();

        internal IFieldAssertionRule OrInternal()
        {
            _context.Or();
            return this;
        }
    }
}
