namespace ArchGuard.Library.Types.Filters
{
    using System;
    using ArchGuard.Library.Types.Filters.Conditions.Interfaces;
    using ArchGuard.Library.Types.Filters.PostConditions.Interfaces;

    public sealed partial class TypesFilter
    {
        public ITypesFilterConditions And()
        {
            _context.And();
            return this;
        }

        public ITypesFilterPostConditions And(
            Func<ITypesFilterConditions, ITypesFilterPostConditions> filter
        )
        {
            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            _context.And();
            filter(this);

            return this;
        }

        public ITypesFilterConditions Or()
        {
            _context.Or();
            return this;
        }

        public ITypesFilterPostConditions Or(
            Func<ITypesFilterConditions, ITypesFilterPostConditions> filter
        )
        {
            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            _context.Or();
            filter(this);

            return this;
        }
    }
}
