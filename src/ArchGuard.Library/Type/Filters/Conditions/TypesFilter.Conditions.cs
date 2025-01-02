namespace ArchGuard.Library.Type.Filters
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Library.Type.Filters.Conditions.Interfaces;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

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

        public ITypesFilterPostConditions ImplementsInterface(Type @interface)
        {
            if (@interface is null)
                throw new ArgumentNullException(nameof(@interface));

            if (!@interface.IsInterface)
                throw new ArgumentException("Type must be an interface", nameof(@interface));

            _context.ApplyFilter(type => type != @interface);
            _context.ApplyFilter(type => @interface.IsAssignableFrom(type));

            return this;
        }

        public ITypesFilterPostConditions ImplementsInterface<T>()
        {
            return ImplementsInterface(typeof(T));
        }
    }
}
