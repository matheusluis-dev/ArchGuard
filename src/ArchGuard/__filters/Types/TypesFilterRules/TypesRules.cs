namespace ArchGuard.Filters.Types;

using System;
using System.Linq;
using ArchGuard.Core.Type.Models;
using ArchGuard.Filters.Base;

public sealed partial class TypesFilterRules : RuleBase<TypeDefinition>
{
    public ISequence<TypesFilterRules, TypeDefinition> ImplementInterface(params Type[] types)
    {
        if (types is null)
            throw new ArgumentNullException(nameof(types));

        if (types.Any(type => !type.IsInterface))
            throw new ArgumentException("Type must be an interface", nameof(types));

        return (ISequence<TypesFilterRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.ImplementInterface(types));
    }

    public ISequence<TypesFilterRules, TypeDefinition> ImplementInterface<T>()
    {
        return ImplementInterface(typeof(T));
    }

    public ISequence<TypesFilterRules, TypeDefinition> DoNotImplementInterface(params Type[] types)
    {
        if (types is null)
            throw new ArgumentNullException(nameof(types));

        if (types.Any(type => !type.IsInterface))
            throw new ArgumentException("Type must be an interface", nameof(types));

        return (ISequence<TypesFilterRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.NotImplementInterface(types));
    }

    public ISequence<TypesFilterRules, TypeDefinition> DoNotImplementInterface<T>()
    {
        return DoNotImplementInterface(typeof(T));
    }

    public ISequence<TypesFilterRules, TypeDefinition> Inherit(params Type[] types)
    {
        if (types is null)
            throw new ArgumentNullException(nameof(types));

        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Inherit(types));
    }

    public ISequence<TypesFilterRules, TypeDefinition> Inherit<T>()
    {
        return Inherit(typeof(T));
    }

    public ISequence<TypesFilterRules, TypeDefinition> DoNotInherit(params Type[] types)
    {
        if (types is null)
            throw new ArgumentNullException(nameof(types));

        return (ISequence<TypesFilterRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.NotInherit(types));
    }

    public ISequence<TypesFilterRules, TypeDefinition> DoNotInherit<T>()
    {
        return DoNotInherit(typeof(T));
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreGeneric()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Generic);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNotGeneric()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotGeneric);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreImmutable()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Immutable);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreMutable()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Mutable);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreStateless()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Stateless);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNotStateless()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotStateless);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreStaticless()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Staticless);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNotStaticless()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotStaticless);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreExternallyImmutable()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.ExternallyImmutable);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreExternallyMutable()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.ExternallyMutable);
    }

    public ISequence<TypesFilterRules, TypeDefinition> HaveDependencyOn(params string[] typesNames)
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.HaveDependencyOn(typesNames));
    }

    public ISequence<TypesFilterRules, TypeDefinition> DoNotHaveDependencyOn(params string[] typesNames)
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.NotHaveDependencyOn(typesNames));
    }

    public ISequence<TypesFilterRules, TypeDefinition> HaveDependencyOnNamespace(params string[] namespaces)
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.HaveDependencyOnNamespace(namespaces));
    }

    public ISequence<TypesFilterRules, TypeDefinition> DoNotHaveDependencyOnNamespace(params string[] namespaces)
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.NotHaveDependencyOnNamespace(namespaces));
    }

    public ISequence<TypesFilterRules, TypeDefinition> HaveDependencyOnlyOnNamespace(params string[] namespaces)
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.HaveDependencyOnlyOnNamespace(namespaces));
    }

    public ISequence<TypesFilterRules, TypeDefinition> HaveParameterlessConstructor()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.HaveParameterlessConstructor);
    }

    public ISequence<TypesFilterRules, TypeDefinition> DoNotHaveParameterlessConstructor()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.NotHaveParameterlessConstructor);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreUsedBy(params string[] typesNames)
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.UsedBy(typesNames));
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNotUsedBy(params string[] typesNames)
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.NotUsedBy(typesNames));
    }
}
