namespace ArchGuard.Library.Type.Filters.Conditions.Interfaces
{
    using ArchGuard.Library.Type.Filters.Common.Interfaces;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public partial interface ITypesFilterConditions : IGetTypes
    {
        ITypesFilterPostConditions ImplementsInterface(System.Type type);
        ITypesFilterPostConditions ImplementsInterface<T>();

        ITypesFilterPostConditions DoNotImplementsInterface(System.Type type);
        ITypesFilterPostConditions DoNotImplementsInterface<T>();

        ITypesFilterPostConditions Inherit(System.Type type);
        ITypesFilterPostConditions Inherit<T>();

        ITypesFilterPostConditions DoNotInherit(System.Type type);
        ITypesFilterPostConditions DoNotInherit<T>();
    }
}
