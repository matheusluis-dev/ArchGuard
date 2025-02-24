namespace ArchGuard.Filters.Types;

using ArchGuard.Core.Type.Models;
using ArchGuard.Filters.Base;

public sealed partial class TypesRules : RuleBase<TypeDefinition>
{
    public ISequence<TypesRules, TypeDefinition> ArePartial()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.Partial);
    }

    public ISequence<TypesRules, TypeDefinition> AreNotPartial()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotPartial);
    }

    public ISequence<TypesRules, TypeDefinition> AreSealed()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.Sealed);
    }

    public ISequence<TypesRules, TypeDefinition> AreNotSealed()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotSealed);
    }

    public ISequence<TypesRules, TypeDefinition> AreNested()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.Nested);
    }

    public ISequence<TypesRules, TypeDefinition> AreNotNested()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotNested);
    }

    public ISequence<TypesRules, TypeDefinition> AreStatic()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.Static);
    }

    public ISequence<TypesRules, TypeDefinition> AreNotStatic()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotStatic);
    }

    public ISequence<TypesRules, TypeDefinition> AreAbstract()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.Abstract);
    }

    public ISequence<TypesRules, TypeDefinition> AreNotAbstract()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotAbstract);
    }
}
