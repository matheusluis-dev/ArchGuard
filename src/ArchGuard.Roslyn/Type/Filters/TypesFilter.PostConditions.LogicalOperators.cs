namespace ArchGuard.Roslyn.Type.Filters
{
    public sealed partial class TypesFilter
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
