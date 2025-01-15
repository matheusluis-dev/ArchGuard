namespace ArchGuard.Library.Type.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Library.Type.Predicates;
    using Microsoft.CodeAnalysis;

    public sealed partial class TypesFilter
    {
        public ITypesFilterConditions That => this;

        public IEnumerable<TypeDefinition> GetTypes()
        {
            return _context.GetTypes(StringComparison.CurrentCulture);
        }

        public IEnumerable<TypeDefinition> GetTypes(StringComparison comparison)
        {
            return _context.GetTypes(comparison);
        }

        public ITypesFilterPostConditions ImplementInterface(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            if (types.Any(type => !type.IsInterface))
                throw new ArgumentException("Type must be an interface", nameof(types));

            _context.AddPredicate(TypePredicate.ImplementInterface(types));

            return this;
        }

        public ITypesFilterPostConditions ImplementInterface<T>()
        {
            return ImplementInterface(typeof(T));
        }

        public ITypesFilterPostConditions DoNotImplementInterface(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            if (types.Any(type => !type.IsInterface))
                throw new ArgumentException("Type must be an interface", nameof(types));

            _context.AddPredicate(TypePredicate.NotImplementInterface(types));

            return this;
        }

        public ITypesFilterPostConditions DoNotImplementInterface<T>()
        {
            return DoNotImplementInterface(typeof(T));
        }

        public ITypesFilterPostConditions Inherit(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            _context.AddPredicate(TypePredicate.Inherit(types));

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

            _context.AddPredicate(TypePredicate.NotInherit(types));

            return this;
        }

        public ITypesFilterPostConditions DoNotInherit<T>()
        {
            return DoNotInherit(typeof(T));
        }

        public ITypesFilterPostConditions AreGeneric()
        {
            _context.AddPredicate(TypePredicate.Generic);
            return this;
        }

        public ITypesFilterPostConditions AreNotGeneric()
        {
            _context.AddPredicate(TypePredicate.NotGeneric);
            return this;
        }

        public ITypesFilterPostConditions AreImmutable()
        {
            _context.AddPredicate(TypePredicate.Immutable);
            return this;
        }

        public ITypesFilterPostConditions AreMutable()
        {
            _context.AddPredicate(TypePredicate.Mutable);
            return this;
        }

        public ITypesFilterPostConditions AreStateless()
        {
            _context.AddPredicate(TypePredicate.Stateless);
            return this;
        }

        public ITypesFilterPostConditions AreNotStateless()
        {
            _context.AddPredicate(TypePredicate.NotStateless);
            return this;
        }

        public ITypesFilterPostConditions AreStaticless()
        {
            _context.AddPredicate(TypePredicate.Staticless);
            return this;
        }

        public ITypesFilterPostConditions AreNotStaticless()
        {
            _context.AddPredicate(TypePredicate.NotStaticless);
            return this;
        }

        public ITypesFilterPostConditions AreExternallyImmutable()
        {
            _context.AddPredicate(TypePredicate.ExternallyImmutable);
            return this;
        }

        public ITypesFilterPostConditions AreExternallyMutable()
        {
            _context.AddPredicate(TypePredicate.ExternallyMutable);
            return this;
        }

        public ITypesFilterPostConditions HaveDependencyOn(params string[] typesNames)
        {
            _context.AddPredicate(TypePredicate.HaveDependencyOn(typesNames));
            return this;
        }

        public ITypesFilterPostConditions DoNotHaveDependencyOn(params string[] typesNames)
        {
            _context.AddPredicate(TypePredicate.NotHaveDependencyOn(typesNames));
            return this;
        }

        public ITypesFilterPostConditions HaveParameterlessConstructor()
        {
            _context.AddPredicate(TypePredicate.HaveParameterlessConstructor);
            return this;
        }

        public ITypesFilterPostConditions DoNotHaveParameterlessConstructor()
        {
            _context.AddPredicate(TypePredicate.NotHaveParameterlessConstructor);
            return this;
        }

        //public ITypesFilterPostConditions AreOfType(params Type[] types)
        //{
        //    _context.AddPredicate(TypePredicate.AreOfType(types));
        //    return this;
        //}

        //public ITypesFilterPostConditions AreOfType<T>()
        //{
        //    return AreOfType(typeof(T));
        //}
    }
}
