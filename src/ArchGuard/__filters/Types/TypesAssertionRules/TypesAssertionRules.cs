namespace ArchGuard.__filters.Types.TypesAssertionRules;

using System.Linq;
using ArchGuard.Core.Type.Models;
using ArchGuard.Filters.Base;

public sealed partial class TypesAssertionRules : RuleBase<TypeDefinition>
{
    public ISequence<TypesAssertionRules, TypeDefinition> ImplementInterface(params Type[] types)
    {
        if (types is null)
            throw new ArgumentNullException(nameof(types));

        if (types.Any(type => !type.IsInterface))
            throw new ArgumentException("Type must be an interface", nameof(types));

        return (ISequence<TypesAssertionRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.ImplementInterface(types));
    }

    public ISequence<TypesAssertionRules, TypeDefinition> ImplementInterface<T>()
    {
        return ImplementInterface(typeof(T));
    }

    public ISequence<TypesAssertionRules, TypeDefinition> NotImplementInterface(params Type[] types)
    {
        if (types is null)
            throw new ArgumentNullException(nameof(types));

        if (types.Any(type => !type.IsInterface))
            throw new ArgumentException("Type must be an interface", nameof(types));

        return (ISequence<TypesAssertionRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.NotImplementInterface(types));
    }

    public ISequence<TypesAssertionRules, TypeDefinition> NotImplementInterface<T>()
    {
        return NotImplementInterface(typeof(T));
    }

    public ISequence<TypesAssertionRules, TypeDefinition> Inherit(params Type[] types)
    {
        if (types is null)
            throw new ArgumentNullException(nameof(types));

        return (ISequence<TypesAssertionRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.Inherit(types));
    }

    public ISequence<TypesAssertionRules, TypeDefinition> Inherit<T>()
    {
        return Inherit(typeof(T));
    }

    public ISequence<TypesAssertionRules, TypeDefinition> NotInherit(params Type[] types)
    {
        if (types is null)
            throw new ArgumentNullException(nameof(types));

        return (ISequence<TypesAssertionRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.NotInherit(types));
    }

    public ISequence<TypesAssertionRules, TypeDefinition> NotInherit<T>()
    {
        return NotInherit(typeof(T));
    }

    public ISequence<TypesAssertionRules, TypeDefinition> BeGeneric()
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Generic);
    }

    public ISequence<TypesAssertionRules, TypeDefinition> NotBeGeneric()
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotGeneric);
    }

    public ISequence<TypesAssertionRules, TypeDefinition> BeImmutable()
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Immutable);
    }

    public ISequence<TypesAssertionRules, TypeDefinition> BeMutable()
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Mutable);
    }

    public ISequence<TypesAssertionRules, TypeDefinition> BeStateless()
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Stateless);
    }

    public ISequence<TypesAssertionRules, TypeDefinition> NotBeStateless()
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotStateless);
    }

    public ISequence<TypesAssertionRules, TypeDefinition> BeStaticless()
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Staticless);
    }

    public ISequence<TypesAssertionRules, TypeDefinition> NotBeStaticless()
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotStaticless);
    }

    public ISequence<TypesAssertionRules, TypeDefinition> BeExternallyImmutable()
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.ExternallyImmutable);
    }

    public ISequence<TypesAssertionRules, TypeDefinition> BeExternallyMutable()
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.ExternallyMutable);
    }

    public ISequence<TypesAssertionRules, TypeDefinition> HaveDependencyOn(params string[] typesNames)
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.HaveDependencyOn(typesNames));
    }

    public ISequence<TypesAssertionRules, TypeDefinition> NotHaveDependencyOn(params string[] typesNames)
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.NotHaveDependencyOn(typesNames));
    }

    public ISequence<TypesAssertionRules, TypeDefinition> HaveDependencyOnNamespace(params string[] namespaces)
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.HaveDependencyOnNamespace(namespaces));
    }

    public ISequence<TypesAssertionRules, TypeDefinition> NotHaveDependencyOnNamespace(params string[] namespaces)
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.NotHaveDependencyOnNamespace(namespaces));
    }

    public ISequence<TypesAssertionRules, TypeDefinition> HaveDependencyOnlyOnNamespace(params string[] namespaces)
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.HaveDependencyOnlyOnNamespace(namespaces));
    }

    public ISequence<TypesAssertionRules, TypeDefinition> HaveParameterlessConstructor()
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.HaveParameterlessConstructor);
    }

    public ISequence<TypesAssertionRules, TypeDefinition> NotHaveParameterlessConstructor()
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.NotHaveParameterlessConstructor);
    }

    public ISequence<TypesAssertionRules, TypeDefinition> BeUsedBy(params string[] typesNames)
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.UsedBy(typesNames));
    }

    public ISequence<TypesAssertionRules, TypeDefinition> NotBeUsedBy(params string[] typesNames)
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.NotUsedBy(typesNames));
    }

    public ISequence<TypesAssertionRules, TypeDefinition> HaveSourceFilePathMatchingNamespace()
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.HaveSourceFilePathMatchingNamespace);
    }

    public ISequence<TypesAssertionRules, TypeDefinition> HaveSourceFileNameMatchingTypeName()
    {
        return (ISequence<TypesAssertionRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.HaveSourceFileNameMatchingTypeName);
    }
}
