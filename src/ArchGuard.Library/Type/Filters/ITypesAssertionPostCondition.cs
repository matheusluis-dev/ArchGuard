namespace ArchGuard.Library.Type.Filters
{
    using System;
    using ArchGuard.Library.Type.Assertions;

#pragma warning disable CA1716 // Identifiers should not match keywords
    public partial interface ITypesAssertionPostCondition
    {
        ITypesAssertionCondition And();
        ITypesAssertionPostCondition And(
            Func<ITypesAssertionCondition, ITypesAssertionPostCondition> filter
        );

        ITypesAssertionCondition Or();
        ITypesAssertionPostCondition Or(
            Func<ITypesAssertionCondition, ITypesAssertionPostCondition> filter
        );

        TypesAssertionResult GetResult();
    }
#pragma warning restore CA1716 // Identifiers should not match keywords
}
