namespace ArchGuard.Library.Type.Filters.PostConditions.Interfaces
{
    using ArchGuard.Library.Type;
    using ArchGuard.Library.Type.Assertions;

    public partial interface ITypesFilterPostConditions : IGetTypes
    {
        ITypesAssertionCondition Should { get; }
    }
}
