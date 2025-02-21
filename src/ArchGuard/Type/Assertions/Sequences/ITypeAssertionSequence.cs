namespace ArchGuard
{
    using System;
    using ArchGuard.Core.Contexts;
    using ArchGuard.Core.Type.Models;

    public partial interface ITypeAssertionSequence
    {
        AssertionResult<TypeDefinition> GetResult();
        AssertionResult<TypeDefinition> GetResult(StringComparison comparison);
    }
}
