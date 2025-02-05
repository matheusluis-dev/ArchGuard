namespace ArchGuard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Core.Type.Models;
    using Microsoft.CodeAnalysis;

    public sealed partial class TypeFilter
    {
        public ITypeFilterRule That => this;

        public IEnumerable<TypeDefinition> GetTypes()
        {
            return _context.GetTypes(Default.StringComparison);
        }

        public IEnumerable<TypeDefinition> GetTypes(StringComparison comparison)
        {
            return _context.GetTypes(comparison);
        }

        public ITypeFilterSequence ImplementInterface(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            if (types.Any(type => !type.IsInterface))
                throw new ArgumentException("Type must be an interface", nameof(types));

            _context.AddPredicate(TypePredicate.ImplementInterface(types));

            return this;
        }

        public ITypeFilterSequence ImplementInterface<T>()
        {
            return ImplementInterface(typeof(T));
        }

        public ITypeFilterSequence DoNotImplementInterface(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            if (types.Any(type => !type.IsInterface))
                throw new ArgumentException("Type must be an interface", nameof(types));

            _context.AddPredicate(TypePredicate.NotImplementInterface(types));

            return this;
        }

        public ITypeFilterSequence DoNotImplementInterface<T>()
        {
            return DoNotImplementInterface(typeof(T));
        }

        public ITypeFilterSequence Inherit(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            _context.AddPredicate(TypePredicate.Inherit(types));

            return this;
        }

        public ITypeFilterSequence Inherit<T>()
        {
            return Inherit(typeof(T));
        }

        public ITypeFilterSequence DoNotInherit(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            _context.AddPredicate(TypePredicate.NotInherit(types));

            return this;
        }

        public ITypeFilterSequence DoNotInherit<T>()
        {
            return DoNotInherit(typeof(T));
        }

        public ITypeFilterSequence AreGeneric()
        {
            _context.AddPredicate(TypePredicate.Generic);
            return this;
        }

        public ITypeFilterSequence AreNotGeneric()
        {
            _context.AddPredicate(TypePredicate.NotGeneric);
            return this;
        }

        public ITypeFilterSequence AreImmutable()
        {
            _context.AddPredicate(TypePredicate.Immutable);
            return this;
        }

        public ITypeFilterSequence AreMutable()
        {
            _context.AddPredicate(TypePredicate.Mutable);
            return this;
        }

        public ITypeFilterSequence AreStateless()
        {
            _context.AddPredicate(TypePredicate.Stateless);
            return this;
        }

        public ITypeFilterSequence AreNotStateless()
        {
            _context.AddPredicate(TypePredicate.NotStateless);
            return this;
        }

        public ITypeFilterSequence AreStaticless()
        {
            _context.AddPredicate(TypePredicate.Staticless);
            return this;
        }

        public ITypeFilterSequence AreNotStaticless()
        {
            _context.AddPredicate(TypePredicate.NotStaticless);
            return this;
        }

        public ITypeFilterSequence AreExternallyImmutable()
        {
            _context.AddPredicate(TypePredicate.ExternallyImmutable);
            return this;
        }

        public ITypeFilterSequence AreExternallyMutable()
        {
            _context.AddPredicate(TypePredicate.ExternallyMutable);
            return this;
        }

        public ITypeFilterSequence HaveDependencyOn(params string[] typesNames)
        {
            _context.AddPredicate(TypePredicate.HaveDependencyOn(typesNames));
            return this;
        }

        public ITypeFilterSequence DoNotHaveDependencyOn(params string[] typesNames)
        {
            _context.AddPredicate(TypePredicate.NotHaveDependencyOn(typesNames));
            return this;
        }

        public ITypeFilterSequence HaveDependencyOnNamespace(params string[] namespaces)
        {
            _context.AddPredicate(TypePredicate.HaveDependencyOnNamespace(namespaces));
            return this;
        }

        public ITypeFilterSequence DoNotHaveDependencyOnNamespace(params string[] namespaces)
        {
            _context.AddPredicate(TypePredicate.NotHaveDependencyOnNamespace(namespaces));
            return this;
        }

        public ITypeFilterSequence HaveDependencyOnlyOnNamespace(params string[] namespaces)
        {
            _context.AddPredicate(TypePredicate.HaveDependencyOnlyOnNamespace(namespaces));
            return this;
        }

        public ITypeFilterSequence HaveParameterlessConstructor()
        {
            _context.AddPredicate(TypePredicate.HaveParameterlessConstructor);
            return this;
        }

        public ITypeFilterSequence DoNotHaveParameterlessConstructor()
        {
            _context.AddPredicate(TypePredicate.NotHaveParameterlessConstructor);
            return this;
        }

        public ITypeFilterSequence AreUsedBy(params string[] typesNames)
        {
            _context.AddPredicate(TypePredicate.UsedBy(typesNames));
            return this;
        }

        public ITypeFilterSequence AreNotUsedBy(params string[] typesNames)
        {
            _context.AddPredicate(TypePredicate.NotUsedBy(typesNames));
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
