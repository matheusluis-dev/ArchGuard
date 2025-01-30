namespace ArchGuard
{
    using System;

    public partial interface ITypeDefinitionAssertionSequence
    {
        TypesAssertionResult GetResult();
        TypesAssertionResult GetResult(StringComparison comparison);
    }
}
