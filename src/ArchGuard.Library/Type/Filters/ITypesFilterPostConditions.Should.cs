namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Assertions;

    public partial interface ITypesFilterPostConditions
    {
        ITypesAssertionCondition Should { get; }
    }
}
