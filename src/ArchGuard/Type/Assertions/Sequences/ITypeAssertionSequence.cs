namespace ArchGuard
{
    using System;

    public partial interface ITypeAssertionSequence
    {
        TypesAssertionResult GetResult();
        TypesAssertionResult GetResult(StringComparison comparison);
    }
}
