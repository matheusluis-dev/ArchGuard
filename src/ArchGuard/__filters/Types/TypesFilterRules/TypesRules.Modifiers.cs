namespace ArchGuard.Filters.Types;

using ArchGuard.Core.Type.Models;
using ArchGuard.Filters.Base;

public sealed partial class TypesFilterRules : RuleBase<TypeDefinition>
{
    public ISequence<TypesFilterRules, TypeDefinition> ArePartial()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Partial);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNotPartial()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotPartial);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreSealed()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Sealed);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNotSealed()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotSealed);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNested()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Nested);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNotNested()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotNested);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreStatic()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Static);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNotStatic()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotStatic);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreAbstract()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Abstract);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNotAbstract()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotAbstract);
    }
}
