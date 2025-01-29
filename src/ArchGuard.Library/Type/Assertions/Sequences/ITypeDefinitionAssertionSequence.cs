namespace ArchGuard.Library.Type.Assertions.Sequences
{
    using System;
    using ArchGuard.Type.Assertions.Models;

    public partial interface ITypeDefinitionAssertionSequence
    {
        TypesAssertionResult GetResult();
        TypesAssertionResult GetResult(StringComparison comparison);
    }
}
