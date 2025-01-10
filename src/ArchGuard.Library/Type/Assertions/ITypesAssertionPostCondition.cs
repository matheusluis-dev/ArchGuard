using ArchGuard.Library.Type.Assertions;

namespace ArchGuard.Library.Type.Assertions
{
    using System;
#pragma warning disable CA1716 // Identifiers should not match keywords
    public partial interface ITypesAssertionPostCondition
    {
        ITypesAssertionCondition And { get; }
        ITypesAssertionCondition Or { get; }

        TypesAssertionResult GetResult();
        TypesAssertionResult GetResult(StringComparison comparison);
    }
#pragma warning restore CA1716 // Identifiers should not match keywords
}
