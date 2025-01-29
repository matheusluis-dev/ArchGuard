namespace ArchGuardType.Filters
{
    public sealed partial class TypeDefinitionFilter
    {
        public ITypeDefinitionFilterRule And => this;

        public ITypeDefinitionFilterRule Or => OrInternal();

        internal ITypeDefinitionFilterRule OrInternal()
        {
            _context.Or();
            return this;
        }
    }
}
