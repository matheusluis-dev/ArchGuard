namespace ArchGuard.Roslyn.Type.Filters
{
    using ArchGuard.Roslyn.Type.Assertions;

    public partial interface ITypesFilterPostConditions
    {
        ITypesAssertionCondition Should { get; }
    }
}
