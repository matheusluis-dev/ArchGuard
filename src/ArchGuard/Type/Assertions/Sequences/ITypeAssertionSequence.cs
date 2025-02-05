namespace ArchGuard
{
    using System;
    using ArchGuard.Core.Type.Models;

    public partial interface ITypeAssertionSequence
    {
        TypeAssertionResult GetResult();
        TypeAssertionResult GetResult(StringComparison comparison);
    }
}
