namespace ArchGuard
{
    public partial interface ITypeFilterRule : IGetTypes
    {
        ITypeFilterSequence ImplementInterface(params System.Type[] types);
        ITypeFilterSequence ImplementInterface<T>();

        ITypeFilterSequence DoNotImplementInterface(params System.Type[] types);
        ITypeFilterSequence DoNotImplementInterface<T>();

        ITypeFilterSequence Inherit(params System.Type[] type);
        ITypeFilterSequence Inherit<T>();

        ITypeFilterSequence DoNotInherit(params System.Type[] types);
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

        //        ITypesFilterPostConditions AreOfType(params System.Type[] types);
        //        ITypesFilterPostConditions AreOfType<T>();
    }
}
