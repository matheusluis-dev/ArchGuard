namespace ArchGuardType.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard;
    using ArchGuard.Type;
    using ArchGuardType.Predicates;
    using Microsoft.CodeAnalysis;

    public sealed partial class TypeDefinitionFilter
    {
        public ITypeDefinitionFilterRule That => this;

        public IEnumerable<TypeDefinition> GetTypes()
        {
            return _context.GetTypes(Default.StringComparison);
        }

        public IEnumerable<TypeDefinition> GetTypes(StringComparison comparison)
        {
            return _context.GetTypes(comparison);
        }

        public ITypeDefinitionFilterSequence ImplementInterface(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            if (types.Any(type => !type.IsInterface))
                throw new ArgumentException("Type must be an interface", nameof(types));

            _context.AddPredicate(TypeDefinitionPredicate.ImplementInterface(types));

            return this;
        }

        public ITypeDefinitionFilterSequence ImplementInterface<T>()
        {
            return ImplementInterface(typeof(T));
        }

        public ITypeDefinitionFilterSequence DoNotImplementInterface(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            if (types.Any(type => !type.IsInterface))
                throw new ArgumentException("Type must be an interface", nameof(types));

            _context.AddPredicate(TypeDefinitionPredicate.NotImplementInterface(types));

            return this;
        }

        public ITypeDefinitionFilterSequence DoNotImplementInterface<T>()
        {
            return DoNotImplementInterface(typeof(T));
        }

        public ITypeDefinitionFilterSequence Inherit(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            _context.AddPredicate(TypeDefinitionPredicate.Inherit(types));

            return this;
        }

        public ITypeDefinitionFilterSequence Inherit<T>()
        {
            return Inherit(typeof(T));
        }

        public ITypeDefinitionFilterSequence DoNotInherit(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            _context.AddPredicate(TypeDefinitionPredicate.NotInherit(types));

            return this;
        }

        public ITypeDefinitionFilterSequence DoNotInherit<T>()
        {
            return DoNotInherit(typeof(T));
        }

        public ITypeDefinitionFilterSequence AreGeneric()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Generic);
            return this;
        }

        public ITypeDefinitionFilterSequence AreNotGeneric()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotGeneric);
            return this;
        }

        public ITypeDefinitionFilterSequence AreImmutable()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Immutable);
            return this;
        }

        public ITypeDefinitionFilterSequence AreMutable()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Mutable);
            return this;
        }

        public ITypeDefinitionFilterSequence AreStateless()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Stateless);
            return this;
        }

        public ITypeDefinitionFilterSequence AreNotStateless()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotStateless);
            return this;
        }

        public ITypeDefinitionFilterSequence AreStaticless()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Staticless);
            return this;
        }

        public ITypeDefinitionFilterSequence AreNotStaticless()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotStaticless);
            return this;
        }

        public ITypeDefinitionFilterSequence AreExternallyImmutable()
        {
            _context.AddPredicate(TypeDefinitionPredicate.ExternallyImmutable);
            return this;
        }

        public ITypeDefinitionFilterSequence AreExternallyMutable()
        {
            _context.AddPredicate(TypeDefinitionPredicate.ExternallyMutable);
            return this;
        }

        public ITypeDefinitionFilterSequence HaveDependencyOn(params string[] typesNames)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveDependencyOn(typesNames));
            return this;
        }

        public ITypeDefinitionFilterSequence DoNotHaveDependencyOn(params string[] typesNames)
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotHaveDependencyOn(typesNames));
            return this;
        }

        public ITypeDefinitionFilterSequence HaveParameterlessConstructor()
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveParameterlessConstructor);
            return this;
        }

        public ITypeDefinitionFilterSequence DoNotHaveParameterlessConstructor()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotHaveParameterlessConstructor);
            return this;
        }

        public ITypeDefinitionFilterSequence AreUsedBy(params string[] typesNames)
        {
            _context.AddPredicate(TypeDefinitionPredicate.UsedBy(typesNames));
            return this;
        }

        public ITypeDefinitionFilterSequence AreNotUsedBy(params string[] typesNames)
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
