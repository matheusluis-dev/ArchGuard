namespace ArchGuard.Library.Type.Filters
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Library.Type.Filters.Conditions.Interfaces;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterConditions That => this;

        public IEnumerable<Type> GetTypes()
        {
            return _context.Types;
        }

        public ITypesFilterPostConditions ImplementInterface(Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (!type.IsInterface)
                throw new ArgumentException("Type must be an interface", nameof(type));

            _context.ApplyFilter(TypePredicate.ImplementInterface(type));

            return this;
        }

        public ITypesFilterPostConditions ImplementInterface<T>()
        {
            return ImplementInterface(typeof(T));
        }

        public ITypesFilterPostConditions DoNotImplementsInterface(Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (!type.IsInterface)
                throw new ArgumentException("Type must be an interface", nameof(type));

            _context.ApplyFilter(TypePredicate.DoNotImplementInterface(type));

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

            _context.ApplyFilter(TypePredicate.Inherit(type));

            return this;
        }

        public ITypesFilterPostConditions Inherit<T>()
        {
            return Inherit(typeof(T));
        }

        public ITypesFilterPostConditions DoNotInherit(Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (!type.IsClass)
                throw new ArgumentException("Type must be a class", nameof(type));

            _context.ApplyFilter(TypePredicate.NotInherit(type));

            return this;
        }

        public ITypesFilterPostConditions DoNotInherit<T>()
        {
            return DoNotInherit(typeof(T));
        }

        public ITypesFilterPostConditions AreGeneric()
        {
            _context.ApplyFilter(TypePredicate.Generic);
            return this;
        }

        public ITypesFilterPostConditions AreNotGeneric()
        {
            _context.ApplyFilter(TypePredicate.NotGeneric);
            return this;
        }

        public ITypesFilterPostConditions AreOfType(Type type)
        {
            _context.ApplyFilter(TypePredicate.AreOfType(type));
            return this;
        }

        public ITypesFilterPostConditions AreOfType<T>()
        {
            return AreOfType(typeof(T));
        }
    }
}
