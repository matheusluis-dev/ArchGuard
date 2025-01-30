namespace ArchGuard
{
    public sealed partial class TypeAssertion
    {
        public ITypeAssertionRule And => this;

        public ITypeAssertionRule Or => OrInternal();

        internal ITypeAssertionRule OrInternal()
        {
            _context.Or();
            return this;
        }
    }
}
