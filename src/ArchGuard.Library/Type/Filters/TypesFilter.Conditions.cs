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
            return _context.GetTypes(Default.StringComparison);
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

            _context.AddPredicate(TypeDefinitionPredicate.ImplementInterface(types));

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

            _context.AddPredicate(TypeDefinitionPredicate.NotImplementInterface(types));

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

            _context.AddPredicate(TypeDefinitionPredicate.Inherit(types));

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

            _context.AddPredicate(TypeDefinitionPredicate.NotInherit(types));

            return this;
        }

        public ITypesFilterPostConditions DoNotInherit<T>()
        {
            return DoNotInherit(typeof(T));
        }

        public ITypesFilterPostConditions AreGeneric()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Generic);
            return this;
        }

        public ITypesFilterPostConditions AreNotGeneric()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotGeneric);
            return this;
        }

        public ITypesFilterPostConditions AreImmutable()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Immutable);
            return this;
        }

        public ITypesFilterPostConditions AreMutable()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Mutable);
            return this;
        }

        public ITypesFilterPostConditions AreStateless()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Stateless);
            return this;
        }

        public ITypesFilterPostConditions AreNotStateless()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotStateless);
            return this;
        }

        public ITypesFilterPostConditions AreStaticless()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Staticless);
            return this;
        }

        public ITypesFilterPostConditions AreNotStaticless()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotStaticless);
            return this;
        }

        public ITypesFilterPostConditions AreExternallyImmutable()
        {
            _context.AddPredicate(TypeDefinitionPredicate.ExternallyImmutable);
            return this;
        }

        public ITypesFilterPostConditions AreExternallyMutable()
        {
            _context.AddPredicate(TypeDefinitionPredicate.ExternallyMutable);
            return this;
        }

        public ITypesFilterPostConditions HaveDependencyOn(params string[] typesNames)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveDependencyOn(typesNames));
            return this;
        }

        public ITypesFilterPostConditions DoNotHaveDependencyOn(params string[] typesNames)
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotHaveDependencyOn(typesNames));
            return this;
        }

        public ITypesFilterPostConditions HaveParameterlessConstructor()
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveParameterlessConstructor);
            return this;
        }

        public ITypesFilterPostConditions DoNotHaveParameterlessConstructor()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotHaveParameterlessConstructor);
            return this;
        }

        public ITypesFilterPostConditions AreUsedBy(params string[] typesNames)
        {
            _context.AddPredicate(TypeDefinitionPredicate.UsedBy(typesNames));
            return this;
        }

        public ITypesFilterPostConditions AreNotUsedBy(params string[] typesNames)
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotUsedBy(typesNames));
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
