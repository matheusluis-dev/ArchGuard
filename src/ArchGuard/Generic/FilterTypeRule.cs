namespace ArchGuard.Generic;

using ArchGuard.Core.Type.Models;

public sealed class FilterTypeRule : IRule<TypeDefinition>
{
    public AddSequenceCallback<IRule<TypeDefinition>, TypeDefinition> AddSequenceCallback { get; set; } = null!;

    public IFilterSequence<FilterTypeRule, TypeDefinition> AreClasses()
    {
        return (IFilterSequence<FilterTypeRule, TypeDefinition>)AddSequenceCallback.Invoke(TypePredicate.Class);
    }
}
