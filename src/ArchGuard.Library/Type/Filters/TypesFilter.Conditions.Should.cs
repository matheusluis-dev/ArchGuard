namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Assertions;

    public sealed partial class TypesFilter
    {
        public ITypesAssertionCondition Should
        {
            get
            {
                var context = new TypesAssertionContext(
                    _context.GetRawTypes(),
                    _context.GetFilters()
                );

                return TypesAssertion.Create(context);
            }
        }
    }
}
