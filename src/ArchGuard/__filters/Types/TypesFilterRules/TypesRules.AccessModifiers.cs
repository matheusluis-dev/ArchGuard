namespace ArchGuard.Filters.Types;

using ArchGuard.Core.Type.Models;
using ArchGuard.Filters.Base;

public sealed partial class TypesFilterRules : RuleBase<TypeDefinition>
{
    public ISequence<TypesFilterRules, TypeDefinition> ArePublic()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Public);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNotPublic()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotPublic);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreInternal()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Internal);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNotInternal()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotInternal);
    }

    public ISequence<TypesFilterRules, TypeDefinition> ArePrivate()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Private);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNotPrivate()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotPrivate);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreProtected()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Protected);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNotProtected()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotProtected);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreFileLocal()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.FileLocal);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNotFileLocal()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotFileLocal);
    }
}
