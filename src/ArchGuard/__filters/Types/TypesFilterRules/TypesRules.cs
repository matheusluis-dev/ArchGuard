namespace ArchGuard.Filters.Types;

using System;
using System.Linq;
using ArchGuard.Core.Type.Models;
using ArchGuard.Filters.Base;

public sealed partial class TypesRules : RuleBase<TypeDefinition>
{
    public ISequence<TypesRules, TypeDefinition> ImplementInterface(params Type[] types)
    {
        if (types is null)
            throw new ArgumentNullException(nameof(types));

        if (types.Any(type => !type.IsInterface))
            throw new ArgumentException("Type must be an interface", nameof(types));

        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.ImplementInterface(types));
    }

    public ISequence<TypesRules, TypeDefinition> ImplementInterface<T>()
    {
        return ImplementInterface(typeof(T));
    }

    public ISequence<TypesRules, TypeDefinition> DoNotImplementInterface(params Type[] types)
    {
        if (types is null)
            throw new ArgumentNullException(nameof(types));

        if (types.Any(type => !type.IsInterface))
            throw new ArgumentException("Type must be an interface", nameof(types));

        return (ISequence<TypesRules, TypeDefinition>)
            SequenceCallback.Invoke(TypePredicate.NotImplementInterface(types));
    }

    public ISequence<TypesRules, TypeDefinition> DoNotImplementInterface<T>()
    {
        return DoNotImplementInterface(typeof(T));
    }

    public ISequence<TypesRules, TypeDefinition> Inherit(params Type[] types)
    {
        if (types is null)
            throw new ArgumentNullException(nameof(types));

        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.Inherit(types));
    }

    public ISequence<TypesRules, TypeDefinition> Inherit<T>()
    {
        return Inherit(typeof(T));
    }

    public ISequence<TypesRules, TypeDefinition> DoNotInherit(params Type[] types)
    {
        if (types is null)
            throw new ArgumentNullException(nameof(types));

        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotInherit(types));
    }

    public ISequence<TypesRules, TypeDefinition> DoNotInherit<T>()
    {
        return DoNotInherit(typeof(T));
    }

    public ISequence<TypesRules, TypeDefinition> AreGeneric()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.Generic);
    }

    public ISequence<TypesRules, TypeDefinition> AreNotGeneric()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotGeneric);
    }

    public ISequence<TypesRules, TypeDefinition> AreImmutable()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.Immutable);
    }

    public ISequence<TypesRules, TypeDefinition> AreMutable()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.Mutable);
    }

    public ISequence<TypesRules, TypeDefinition> AreStateless()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.Stateless);
    }

    public ISequence<TypesRules, TypeDefinition> AreNotStateless()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotStateless);
    }

    public ISequence<TypesRules, TypeDefinition> AreStaticless()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.Staticless);
    }

    public ISequence<TypesRules, TypeDefinition> AreNotStaticless()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotStaticless);
    }

    public ISequence<TypesRules, TypeDefinition> AreExternallyImmutable()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.ExternallyImmutable);
    }

    public ISequence<TypesRules, TypeDefinition> AreExternallyMutable()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.ExternallyMutable);
    }

    public ISequence<TypesRules, TypeDefinition> HaveDependencyOn(params string[] typesNames)
    {
        return (ISequence<TypesRules, TypeDefinition>)
            SequenceCallback.Invoke(TypePredicate.HaveDependencyOn(typesNames));
    }

    public ISequence<TypesRules, TypeDefinition> DoNotHaveDependencyOn(params string[] typesNames)
    {
        return (ISequence<TypesRules, TypeDefinition>)
            SequenceCallback.Invoke(TypePredicate.NotHaveDependencyOn(typesNames));
    }

    public ISequence<TypesRules, TypeDefinition> HaveDependencyOnNamespace(params string[] namespaces)
    {
        return (ISequence<TypesRules, TypeDefinition>)
            SequenceCallback.Invoke(TypePredicate.HaveDependencyOnNamespace(namespaces));
    }

    public ISequence<TypesRules, TypeDefinition> DoNotHaveDependencyOnNamespace(params string[] namespaces)
    {
        return (ISequence<TypesRules, TypeDefinition>)
            SequenceCallback.Invoke(TypePredicate.NotHaveDependencyOnNamespace(namespaces));
    }

    public ISequence<TypesRules, TypeDefinition> HaveDependencyOnlyOnNamespace(params string[] namespaces)
    {
        return (ISequence<TypesRules, TypeDefinition>)
            SequenceCallback.Invoke(TypePredicate.HaveDependencyOnlyOnNamespace(namespaces));
    }

    public ISequence<TypesRules, TypeDefinition> HaveParameterlessConstructor()
    {
        return (ISequence<TypesRules, TypeDefinition>)
            SequenceCallback.Invoke(TypePredicate.HaveParameterlessConstructor);
    }

    public ISequence<TypesRules, TypeDefinition> DoNotHaveParameterlessConstructor()
    {
        return (ISequence<TypesRules, TypeDefinition>)
            SequenceCallback.Invoke(TypePredicate.NotHaveParameterlessConstructor);
    }

    public ISequence<TypesRules, TypeDefinition> AreUsedBy(params string[] typesNames)
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.UsedBy(typesNames));
    }

    public ISequence<TypesRules, TypeDefinition> AreNotUsedBy(params string[] typesNames)
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotUsedBy(typesNames));
    }
}
