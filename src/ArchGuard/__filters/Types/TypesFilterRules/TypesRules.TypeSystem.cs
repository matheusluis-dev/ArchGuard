namespace ArchGuard.Filters.Types;

using ArchGuard.Core.Type.Models;
using ArchGuard.Filters.Base;

public sealed partial class TypesFilterRules : RuleBase<TypeDefinition>
{
    public ISequence<TypesFilterRules, TypeDefinition> AreClasses()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Class);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNotClasses()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotClass);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreInterfaces()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Interface);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNotInterfaces()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotInterface);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreStructs()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Struct);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNotStructs()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotStruct);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreEnums()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Enum);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNotEnums()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotEnum);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreRecords()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.Record);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNotRecords()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotRecord);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreRecordStructs()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.RecordStruct);
    }

    public ISequence<TypesFilterRules, TypeDefinition> AreNotRecordStructs()
    {
        return (ISequence<TypesFilterRules, TypeDefinition>)AddPredicateCallback.Invoke(TypePredicate.NotRecordStruct);
    }
}
