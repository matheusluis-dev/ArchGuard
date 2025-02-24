namespace ArchGuard.Filters.Types;

using ArchGuard.Core.Type.Models;
using ArchGuard.Filters.Base;

public sealed partial class TypesRules : RuleBase<TypeDefinition>
{
    public ISequence<TypesRules, TypeDefinition> AreClasses()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.Class);
    }

    public ISequence<TypesRules, TypeDefinition> AreNotClasses()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotClass);
    }

    public ISequence<TypesRules, TypeDefinition> AreInterfaces()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.Interface);
    }

    public ISequence<TypesRules, TypeDefinition> AreNotInterfaces()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotInterface);
    }

    public ISequence<TypesRules, TypeDefinition> AreStructs()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.Struct);
    }

    public ISequence<TypesRules, TypeDefinition> AreNotStructs()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotStruct);
    }

    public ISequence<TypesRules, TypeDefinition> AreEnums()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.Enum);
    }

    public ISequence<TypesRules, TypeDefinition> AreNotEnums()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotEnum);
    }

    public ISequence<TypesRules, TypeDefinition> AreRecords()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.Record);
    }

    public ISequence<TypesRules, TypeDefinition> AreNotRecords()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotRecord);
    }

    public ISequence<TypesRules, TypeDefinition> AreRecordStructs()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.RecordStruct);
    }

    public ISequence<TypesRules, TypeDefinition> AreNotRecordStructs()
    {
        return (ISequence<TypesRules, TypeDefinition>)SequenceCallback.Invoke(TypePredicate.NotRecordStruct);
    }
}
