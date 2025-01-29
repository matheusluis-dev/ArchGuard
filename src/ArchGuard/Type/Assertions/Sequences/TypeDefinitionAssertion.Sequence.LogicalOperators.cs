namespace ArchGuardType.Assertions
{
    public sealed partial class TypeDefinitionAssertion
    {
        public ITypeDefinitionAssertionRule And => this;

        public ITypeDefinitionAssertionRule Or => OrInternal();

        internal ITypeDefinitionAssertionRule OrInternal()
        {
            _context.Or();
            return this;
        }
    }
}
