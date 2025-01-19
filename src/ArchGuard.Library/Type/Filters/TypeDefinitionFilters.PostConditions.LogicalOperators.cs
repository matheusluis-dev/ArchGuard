namespace ArchGuard.Library.Type.Filters
{
    public sealed partial class TypeDefinitionFilters
    {
        public ITypesFilterConditions And => this;

        public ITypesFilterConditions Or => OrInternal();

        internal ITypesFilterConditions OrInternal()
        {
            _context.Or();
            return this;
        }
    }
}
