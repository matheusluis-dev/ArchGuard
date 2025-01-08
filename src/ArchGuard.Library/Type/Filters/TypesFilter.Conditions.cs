namespace ArchGuard.Library.Type.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Library.Type.Filters.Conditions.Interfaces;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterConditions That => this;

        public IEnumerable<TypeSpecRoslyn> GetTypes()
        {
            return _context.GetTypes(StringComparison.CurrentCulture);
        }

        public IEnumerable<TypeSpecRoslyn> GetTypes(StringComparison comparison)
        {
            return _context.GetTypes(comparison);
        }

        public ITypesFilterPostConditions ImplementInterface(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            if (types.Any(type => !type.IsInterface))
                throw new ArgumentException("Type must be an interface", nameof(types));

            _context.AddPredicate(TypeSpecPredicate.ImplementInterface(types));

            return this;
        }

        public ITypesFilterPostConditions ImplementInterface<T>()
        {
            return ImplementInterface(typeof(T));
        }

        public ITypesFilterPostConditions DoNotImplementsInterface(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            if (types.Any(type => !type.IsInterface))
                throw new ArgumentException("Type must be an interface", nameof(types));

            _context.AddPredicate(TypeSpecPredicate.DoNotImplementInterface(types));

            return this;
        }

        public ITypesFilterPostConditions DoNotImplementsInterface<T>()
        {
            return DoNotImplementsInterface(typeof(T));
        }

        public ITypesFilterPostConditions Inherit(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            if (types.Any(type => !type.IsClass))
                throw new ArgumentException("Type must be a class", nameof(types));

            _context.AddPredicate(TypeSpecPredicate.Inherit(types));

            return this;
        }

        public ITypesFilterPostConditions Inherit<T>()
        {
            return Inherit(typeof(T));
        }

        public ITypesFilterPostConditions DoNotInherit(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            if (types.Any(type => !type.IsClass))
                throw new ArgumentException("Type must be a class", nameof(types));

            _context.AddPredicate(TypeSpecPredicate.NotInherit(types));

            return this;
        }

        public ITypesFilterPostConditions DoNotInherit<T>()
        {
            return DoNotInherit(typeof(T));
        }

        public ITypesFilterPostConditions AreGeneric()
        {
            _context.AddPredicate(TypeSpecPredicate.Generic);
            return this;
        }

        public ITypesFilterPostConditions AreNotGeneric()
        {
            _context.AddPredicate(TypeSpecPredicate.NotGeneric);
            return this;
        }

        public ITypesFilterPostConditions AreOfType(params Type[] types)
        {
            _context.AddPredicate(TypeSpecPredicate.AreOfType(types));
            return this;
        }

        public ITypesFilterPostConditions AreOfType<T>()
        {
            return AreOfType(typeof(T));
        }
    }
}
