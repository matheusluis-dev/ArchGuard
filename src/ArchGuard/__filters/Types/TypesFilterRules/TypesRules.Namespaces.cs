namespace ArchGuard.Filters.Types;

using ArchGuard.Core.Type.Models;
using ArchGuard.Filters.Base;

public sealed partial class TypesRules : RuleBase<TypeDefinition>
{
    public ISequence<TypesRules, TypeDefinition> ResideInNamespace(params string[] names)
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.ResideInNamespace(names));
    }

    public ISequence<TypesRules, TypeDefinition> ResideInNamespaceContaining(params string[] names)
    {
        return (ISequence<TypesRules, TypeDefinition>)
            SequenceCallback.Invoke(TypePredicate.ResideInNamespaceContaining(names));
    }

    public ISequence<TypesRules, TypeDefinition> ResideInNamespaceEndingWith(params string[] names)
    {
        return (ISequence<TypesRules, TypeDefinition>)
            SequenceCallback.Invoke(TypePredicate.ResideInNamespaceEndingWith(names));
    }

    public ISequence<TypesRules, TypeDefinition> DoNotResideInNamespace(params string[] names)
    {
        return (ISequence<TypesRules, TypeDefinition>)
            SequenceCallback.Invoke(TypePredicate.DoNotResideInNamespace(names));
    }

    public ISequence<TypesRules, TypeDefinition> DoNotResideInNamespaceContaining(params string[] names)
    {
        return (ISequence<TypesRules, TypeDefinition>)
            SequenceCallback.Invoke(TypePredicate.DoNotResideInNamespaceContaining(names));
    }

    public ISequence<TypesRules, TypeDefinition> DoNotResideInNamespaceEndingWith(params string[] names)
    {
        return (ISequence<TypesRules, TypeDefinition>)
            SequenceCallback.Invoke(TypePredicate.DoNotResideInNamespaceEndingWith(names));
    }
}
