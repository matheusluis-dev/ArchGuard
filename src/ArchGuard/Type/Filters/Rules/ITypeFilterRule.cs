namespace ArchGuard
{
    public partial interface ITypeFilterRule : IGetTypes
    {
        ITypeFilterSequence ImplementInterface(params Type[] types);
        ITypeFilterSequence ImplementInterface<T>();

        ITypeFilterSequence DoNotImplementInterface(params Type[] types);
        ITypeFilterSequence DoNotImplementInterface<T>();

        ITypeFilterSequence Inherit(params Type[] type);
        ITypeFilterSequence Inherit<T>();

        ITypeFilterSequence DoNotInherit(params Type[] types);
        ITypeFilterSequence DoNotInherit<T>();

        ITypeFilterSequence AreGeneric();
        ITypeFilterSequence AreNotGeneric();

        ITypeFilterSequence AreImmutable();
        ITypeFilterSequence AreMutable();

        ITypeFilterSequence AreStateless();
        ITypeFilterSequence AreNotStateless();

        ITypeFilterSequence AreStaticless();
        ITypeFilterSequence AreNotStaticless();

        ITypeFilterSequence AreExternallyImmutable();
        ITypeFilterSequence AreExternallyMutable();

        ITypeFilterSequence HaveDependencyOn(params string[] typesNames);
        ITypeFilterSequence DoNotHaveDependencyOn(params string[] typesNames);

        ITypeFilterSequence AreUsedBy(params string[] typesNames);
        ITypeFilterSequence AreNotUsedBy(params string[] typesNames);

        ITypeFilterSequence HaveParameterlessConstructor();
        ITypeFilterSequence DoNotHaveParameterlessConstructor();

        //        ITypesFilterPostConditions AreOfType(params Type[] types);
        //        ITypesFilterPostConditions AreOfType<T>();
    }
}
