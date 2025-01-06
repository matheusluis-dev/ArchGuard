namespace ArchGuard.Library.Type.Filters.PostConditions.Interfaces
{
    using ArchGuard.Library.Type.Assertions;

    public partial interface ITypesFilterPostConditions
    {
        ITypesAssertionCondition Should { get; }
    }
}
