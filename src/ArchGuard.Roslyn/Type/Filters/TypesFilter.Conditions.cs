namespace ArchGuard.Roslyn.Type.Filters
{
    using System;
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis;

    public sealed partial class TypesFilter
    {
        public ITypesFilterConditions That => this;

        public IEnumerable<INamedTypeSymbol> GetTypes()
        {
            return _context.GetTypes(StringComparison.CurrentCulture);
        }

        public IEnumerable<INamedTypeSymbol> GetTypes(StringComparison comparison)
        {
            return _context.GetTypes(comparison);
        }

        //public ITypesFilterPostConditions ImplementInterface(params Type[] types)
        //{
        //    if (types is null)
        //        throw new ArgumentNullException(nameof(types));

        //    if (types.Any(type => !type.IsInterface))
        //        throw new ArgumentException("Type must be an interface", nameof(types));

        //    _context.AddPredicate(TypePredicate.ImplementInterface(types));

        //    return this;
        //}

        //public ITypesFilterPostConditions ImplementInterface<T>()
        //{
        //    return ImplementInterface(typeof(T));
        //}

        //public ITypesFilterPostConditions DoNotImplementsInterface(params Type[] types)
        //{
        //    if (types is null)
        //        throw new ArgumentNullException(nameof(types));

        //    if (types.Any(type => !type.IsInterface))
        //        throw new ArgumentException("Type must be an interface", nameof(types));

        //    _context.AddPredicate(TypePredicate.DoNotImplementInterface(types));

        //    return this;
        //}

        //public ITypesFilterPostConditions DoNotImplementsInterface<T>()
        //{
        //    return DoNotImplementsInterface(typeof(T));
        //}

        //public ITypesFilterPostConditions Inherit(params Type[] types)
        //{
        //    if (types is null)
        //        throw new ArgumentNullException(nameof(types));

        //    if (types.Any(type => !type.IsClass))
        //        throw new ArgumentException("Type must be a class", nameof(types));

        //    _context.AddPredicate(TypePredicate.Inherit(types));

        //    return this;
        //}

        //public ITypesFilterPostConditions Inherit<T>()
        //{
        //    return Inherit(typeof(T));
        //}

        //public ITypesFilterPostConditions DoNotInherit(params Type[] types)
        //{
        //    if (types is null)
        //        throw new ArgumentNullException(nameof(types));

        //    if (types.Any(type => !type.IsClass))
        //        throw new ArgumentException("Type must be a class", nameof(types));

        //    _context.AddPredicate(TypePredicate.NotInherit(types));

        //    return this;
        //}

        //public ITypesFilterPostConditions DoNotInherit<T>()
        //{
        //    return DoNotInherit(typeof(T));
        //}

        //public ITypesFilterPostConditions AreGeneric()
        //{
        //    _context.AddPredicate(TypePredicate.Generic);
        //    return this;
        //}

        //public ITypesFilterPostConditions AreNotGeneric()
        //{
        //    _context.AddPredicate(TypePredicate.NotGeneric);
        //    return this;
        //}

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
