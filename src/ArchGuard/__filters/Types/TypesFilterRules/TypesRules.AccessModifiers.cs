namespace ArchGuard.Filters.Types;

using ArchGuard.Core.Type.Models;
using ArchGuard.Filters.Base;

public sealed partial class TypesRules : RuleBase<TypeDefinition>
{
    public ISequence<TypesRules, TypeDefinition> ArePublic()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.Public);
    }

    public ISequence<TypesRules, TypeDefinition> AreNotPublic()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotPublic);
    }

    public ISequence<TypesRules, TypeDefinition> AreInternal()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.Internal);
    }

    public ISequence<TypesRules, TypeDefinition> AreNotInternal()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotInternal);
    }

    public ISequence<TypesRules, TypeDefinition> ArePrivate()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.Private);
    }

    public ISequence<TypesRules, TypeDefinition> AreNotPrivate()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotPrivate);
    }

    public ISequence<TypesRules, TypeDefinition> AreProtected()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.Protected);
    }

    public ISequence<TypesRules, TypeDefinition> AreNotProtected()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotProtected);
    }

    public ISequence<TypesRules, TypeDefinition> AreFileLocal()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.FileLocal);
    }

    public ISequence<TypesRules, TypeDefinition> AreNotFileLocal()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotFileLocal);
    }
}
