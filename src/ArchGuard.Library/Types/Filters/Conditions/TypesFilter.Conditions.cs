namespace ArchGuard.Library.Types.Filters
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Library.Types.Filters.Conditions.Interfaces;
    using ArchGuard.Library.Types.Filters.PostConditions.Interfaces;

    public sealed partial class TypesFilter
    {
        public ITypesFilterConditions That()
        {
            return this;
        }

        public ITypesFilterPostConditions That(
            Func<ITypesFilterConditions, ITypesFilterPostConditions> filter
        )
        {
            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            filter(this);

            return this;
        }

        public IEnumerable<Type> GetTypes()
        {
            return _context.Types;
        }
    }
}
