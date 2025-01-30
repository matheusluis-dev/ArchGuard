namespace ArchGuard
{
    using System;
    using System.Linq;

    public sealed partial class TypeAssertion
    {
        public ITypeAssertionSequence ImplementInterface(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            if (types.Any(type => !type.IsInterface))
                throw new ArgumentException("Type must be an interface", nameof(types));

            _context.AddPredicate(TypePredicate.ImplementInterface(types));

            return this;
        }

        public ITypeAssertionSequence ImplementInterface<T>()
        {
            return ImplementInterface(typeof(T));
        }

        public ITypeAssertionSequence NotImplementInterface(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            if (types.Any(type => !type.IsInterface))
                throw new ArgumentException("Type must be an interface", nameof(types));

            _context.AddPredicate(TypePredicate.NotImplementInterface(types));

            return this;
        }

        public ITypeAssertionSequence NotImplementInterface<T>()
        {
            return NotImplementInterface(typeof(T));
        }

        public ITypeAssertionSequence Inherit(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            _context.AddPredicate(TypePredicate.Inherit(types));

            return this;
        }

        public ITypeAssertionSequence Inherit<T>()
        {
            return Inherit(typeof(T));
        }

        public ITypeAssertionSequence NotInherit(params Type[] types)
        {
            if (types is null)
                throw new ArgumentNullException(nameof(types));

            _context.AddPredicate(TypePredicate.NotInherit(types));

            return this;
        }

        public ITypeAssertionSequence NotInherit<T>()
        {
            return NotInherit(typeof(T));
        }

        public ITypeAssertionSequence BeGeneric()
        {
            _context.AddPredicate(TypePredicate.Generic);
            return this;
        }

        public ITypeAssertionSequence NotBeGeneric()
        {
            _context.AddPredicate(TypePredicate.NotGeneric);
            return this;
        }

        public ITypeAssertionSequence BeImmutable()
        {
            _context.AddPredicate(TypePredicate.Immutable);
            return this;
        }

        public ITypeAssertionSequence BeMutable()
        {
            _context.AddPredicate(TypePredicate.Mutable);
            return this;
        }

        public ITypeAssertionSequence BeStateless()
        {
            _context.AddPredicate(TypePredicate.Stateless);
            return this;
        }

        public ITypeAssertionSequence NotBeStateless()
        {
            _context.AddPredicate(TypePredicate.NotStateless);
            return this;
        }

        public ITypeAssertionSequence BeStaticless()
        {
            _context.AddPredicate(TypePredicate.Staticless);
            return this;
        }

        public ITypeAssertionSequence NotBeStaticless()
        {
            _context.AddPredicate(TypePredicate.NotStaticless);
            return this;
        }

        public ITypeAssertionSequence BeExternallyImmutable()
        {
            _context.AddPredicate(TypePredicate.ExternallyImmutable);
            return this;
        }

        public ITypeAssertionSequence BeExternallyMutable()
        {
            _context.AddPredicate(TypePredicate.ExternallyMutable);
            return this;
        }

        public ITypeAssertionSequence HaveDependencyOn(params string[] typesNames)
        {
            _context.AddPredicate(TypePredicate.HaveDependencyOn(typesNames));
            return this;
        }

        public ITypeAssertionSequence NotHaveDependencyOn(params string[] typesNames)
        {
            _context.AddPredicate(TypePredicate.NotHaveDependencyOn(typesNames));
            return this;
        }

        public ITypeAssertionSequence HaveParameterlessConstructor()
        {
            _context.AddPredicate(TypePredicate.HaveParameterlessConstructor);
            return this;
        }

        public ITypeAssertionSequence NotHaveParameterlessConstructor()
        {
            _context.AddPredicate(TypePredicate.NotHaveParameterlessConstructor);
            return this;
        }

        public ITypeAssertionSequence BeUsedBy(params string[] typesNames)
        {
            _context.AddPredicate(TypePredicate.UsedBy(typesNames));
            return this;
        }

        public ITypeAssertionSequence NotBeUsedBy(params string[] typesNames)
        {
            _context.AddPredicate(TypePredicate.NotUsedBy(typesNames));
            return this;
        }
    }
}
