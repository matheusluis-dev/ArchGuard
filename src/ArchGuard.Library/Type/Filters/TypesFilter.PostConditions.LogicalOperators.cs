namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Filters.Conditions.Interfaces;

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
