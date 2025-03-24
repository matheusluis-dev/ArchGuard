namespace ArchGuard.Filters.Types;

using ArchGuard.Core.Type.Models;
using ArchGuard.Filters.Base;

public sealed partial class TypesFilterRules : RuleBase<TypeDefinition>
{
    public ISequence<TypesFilterRules, TypeDefinition> ResideInNamespace(params string[] names)
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.ResideInNamespace(names));
    }

    public ISequence<TypesFilterRules, TypeDefinition> ResideInNamespaceContaining(params string[] names)
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.ResideInNamespaceContaining(names));
    }

    public ISequence<TypesFilterRules, TypeDefinition> ResideInNamespaceEndingWith(params string[] names)
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.ResideInNamespaceEndingWith(names));
    }

    public ISequence<TypesFilterRules, TypeDefinition> DoNotResideInNamespace(params string[] names)
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.DoNotResideInNamespace(names));
    }

    public ISequence<TypesFilterRules, TypeDefinition> DoNotResideInNamespaceContaining(params string[] names)
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.DoNotResideInNamespaceContaining(names));
    }

    public ISequence<TypesFilterRules, TypeDefinition> DoNotResideInNamespaceEndingWith(params string[] names)
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)
            AddPredicateCallback.Invoke(TypePredicate.DoNotResideInNamespaceEndingWith(names));
    }
}
