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

        public ITypesFilterPostConditions ImplementsInterface(Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (!type.IsInterface)
                throw new ArgumentException("Type must be an interface", nameof(type));

            _context.ApplyFilter(t => t != type && type.IsAssignableFrom(t));

            return this;
        }

        public ITypesFilterPostConditions ImplementsInterface<T>()
        {
            return ImplementsInterface(typeof(T));
        }

        public ITypesFilterPostConditions DoNotImplementsInterface(Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (!type.IsInterface)
                throw new ArgumentException("Type must be an interface", nameof(type));

            _context.ApplyFilter(t => !type.IsAssignableFrom(t));

            return this;
        }

        public ITypesFilterPostConditions DoNotImplementsInterface<T>()
        {
            return DoNotImplementsInterface(typeof(T));
        }

        public ITypesFilterPostConditions Inherit(Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (!type.IsClass)
                throw new ArgumentException("Type must be a class", nameof(type));

            _context.ApplyFilter(t => t.IsSubclassOf(type));

            return this;
        }

        public ITypesFilterPostConditions Inherit<T>()
        {
            return Inherit(typeof(T));
        }

        public ITypesFilterPostConditions DoNotInherit(System.Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (!type.IsClass)
                throw new ArgumentException("Type must be a class", nameof(type));

            _context.ApplyFilter(t => !t.IsSubclassOf(type));

            return this;
        }

        public ITypesFilterPostConditions DoNotInherit<T>()
        {
            return DoNotInherit(typeof(T));
        }

        public ITypesFilterPostConditions AreGeneric()
        {
            _context.ApplyFilter(t => t.IsGenericType);
            return this;
        }

        public ITypesFilterPostConditions AreNotGeneric()
        {
            _context.ApplyFilter(t => !t.IsGenericType);
            return this;
        }
    }
}
