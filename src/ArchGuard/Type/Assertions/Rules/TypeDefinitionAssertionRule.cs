namespace ArchGuard
{
    using System;
    using System.Linq;
    using ArchGuardType.Predicates;

    public sealed partial class TypeDefinitionAssertion
    {
        public ITypeDefinitionAssertionSequence ImplementInterface(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            if (types.Any(type => !type.IsInterface))
                throw new ArgumentException("Type must be an interface", nameof(types));

            _context.AddPredicate(TypeDefinitionPredicate.ImplementInterface(types));

            return this;
        }

        public ITypeDefinitionAssertionSequence ImplementInterface<T>()
        {
            return ImplementInterface(typeof(T));
        }

        public ITypeDefinitionAssertionSequence NotImplementInterface(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            if (types.Any(type => !type.IsInterface))
                throw new ArgumentException("Type must be an interface", nameof(types));

            _context.AddPredicate(TypeDefinitionPredicate.NotImplementInterface(types));

            return this;
        }

        public ITypeDefinitionAssertionSequence NotImplementInterface<T>()
        {
            return NotImplementInterface(typeof(T));
        }

        public ITypeDefinitionAssertionSequence Inherit(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            _context.AddPredicate(TypeDefinitionPredicate.Inherit(types));

            return this;
        }

        public ITypeDefinitionAssertionSequence Inherit<T>()
        {
            return Inherit(typeof(T));
        }

        public ITypeDefinitionAssertionSequence NotInherit(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            _context.AddPredicate(TypeDefinitionPredicate.NotInherit(types));

            return this;
        }

        public ITypeDefinitionAssertionSequence NotInherit<T>()
        {
            return NotInherit(typeof(T));
        }

        public ITypeDefinitionAssertionSequence BeGeneric()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Generic);
            return this;
        }

        public ITypeDefinitionAssertionSequence NotBeGeneric()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotGeneric);
            return this;
        }

        public ITypeDefinitionAssertionSequence BeImmutable()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Immutable);
            return this;
        }

        public ITypeDefinitionAssertionSequence BeMutable()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Mutable);
            return this;
        }

        public ITypeDefinitionAssertionSequence BeStateless()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Stateless);
            return this;
        }

        public ITypeDefinitionAssertionSequence NotBeStateless()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotStateless);
            return this;
        }

        public ITypeDefinitionAssertionSequence BeStaticless()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Staticless);
            return this;
        }

        public ITypeDefinitionAssertionSequence NotBeStaticless()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotStaticless);
            return this;
        }

        public ITypeDefinitionAssertionSequence BeExternallyImmutable()
        {
            _context.AddPredicate(TypeDefinitionPredicate.ExternallyImmutable);
            return this;
        }

        public ITypeDefinitionAssertionSequence BeExternallyMutable()
        {
            _context.AddPredicate(TypeDefinitionPredicate.ExternallyMutable);
            return this;
        }

        public ITypeDefinitionAssertionSequence HaveDependencyOn(params string[] typesNames)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveDependencyOn(typesNames));
            return this;
        }

        public ITypeDefinitionAssertionSequence NotHaveDependencyOn(params string[] typesNames)
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotHaveDependencyOn(typesNames));
            return this;
        }

        public ITypeDefinitionAssertionSequence HaveParameterlessConstructor()
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveParameterlessConstructor);
            return this;
        }

        public ITypeDefinitionAssertionSequence NotHaveParameterlessConstructor()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotHaveParameterlessConstructor);
            return this;
        }

        public ITypeDefinitionAssertionSequence BeUsedBy(params string[] typesNames)
        {
            _context.AddPredicate(TypeDefinitionPredicate.UsedBy(typesNames));
            return this;
        }

        public ITypeDefinitionAssertionSequence NotBeUsedBy(params string[] typesNames)
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotUsedBy(typesNames));
            return this;
        }
    }
}
