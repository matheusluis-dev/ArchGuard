namespace ArchGuard.Library.Type.Filters.Conditions.Interfaces
{
    using ArchGuard.Library.Type;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public partial interface ITypesFilterConditions : IGetTypes
    {
        ITypesFilterPostConditions ImplementInterface(System.Type type);
        ITypesFilterPostConditions ImplementInterface<T>();

        ITypesFilterPostConditions DoNotImplementsInterface(System.Type type);
        ITypesFilterPostConditions DoNotImplementsInterface<T>();

        ITypesFilterPostConditions Inherit(System.Type type);
        ITypesFilterPostConditions Inherit<T>();

        ITypesFilterPostConditions DoNotInherit(System.Type type);
        ITypesFilterPostConditions DoNotInherit<T>();

        ITypesFilterPostConditions AreGeneric();
        ITypesFilterPostConditions AreNotGeneric();

        ITypesFilterPostConditions AreOfType(System.Type type);
        ITypesFilterPostConditions AreOfType<T>();
    }
}
