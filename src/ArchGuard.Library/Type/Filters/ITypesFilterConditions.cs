namespace ArchGuard.Library.Type.Filters
{
    public partial interface ITypesFilterConditions : IGetTypes
    {
        ITypesFilterPostConditions ImplementInterface(params System.Type[] types);
        ITypesFilterPostConditions ImplementInterface<T>();

        ITypesFilterPostConditions DoNotImplementsInterface(params System.Type[] types);
        ITypesFilterPostConditions DoNotImplementInterface<T>();

        ITypesFilterPostConditions Inherit(params System.Type[] type);
        ITypesFilterPostConditions Inherit<T>();

        ITypesFilterPostConditions DoNotInherit(params System.Type[] types);
        ITypesFilterPostConditions DoNotInherit<T>();

        ITypesFilterPostConditions AreGeneric();
        ITypesFilterPostConditions AreNotGeneric();

        ITypesFilterPostConditions AreImmutable();
        ITypesFilterPostConditions AreMutable();

        //        ITypesFilterPostConditions AreOfType(params System.Type[] types);
        //        ITypesFilterPostConditions AreOfType<T>();
    }
}
