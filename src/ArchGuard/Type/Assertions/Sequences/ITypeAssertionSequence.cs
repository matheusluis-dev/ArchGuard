namespace ArchGuard
{
    using System;

    public partial interface ITypeAssertionSequence
    {
        TypeAssertionResult GetResult();
        TypeAssertionResult GetResult(StringComparison comparison);
    }
}
