namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Type.Common;

    public partial interface ITypeDefinitionFilterRule : IGetTypes
    {
        ITypeDefinitionFilterSequence ImplementInterface(params System.Type[] types);
        ITypeDefinitionFilterSequence ImplementInterface<T>();

        ITypeDefinitionFilterSequence DoNotImplementInterface(params System.Type[] types);
        ITypeDefinitionFilterSequence DoNotImplementInterface<T>();

        ITypeDefinitionFilterSequence Inherit(params System.Type[] type);
        ITypeDefinitionFilterSequence Inherit<T>();

        ITypeDefinitionFilterSequence DoNotInherit(params System.Type[] types);
        ITypeDefinitionFilterSequence DoNotInherit<T>();

        ITypeDefinitionFilterSequence AreGeneric();
        ITypeDefinitionFilterSequence AreNotGeneric();

        ITypeDefinitionFilterSequence AreImmutable();
        ITypeDefinitionFilterSequence AreMutable();

        ITypeDefinitionFilterSequence AreStateless();
        ITypeDefinitionFilterSequence AreNotStateless();

        ITypeDefinitionFilterSequence AreStaticless();
        ITypeDefinitionFilterSequence AreNotStaticless();

        ITypeDefinitionFilterSequence AreExternallyImmutable();
        ITypeDefinitionFilterSequence AreExternallyMutable();

        ITypeDefinitionFilterSequence HaveDependencyOn(params string[] typesNames);
        ITypeDefinitionFilterSequence DoNotHaveDependencyOn(params string[] typesNames);

        ITypeDefinitionFilterSequence AreUsedBy(params string[] typesNames);
        ITypeDefinitionFilterSequence AreNotUsedBy(params string[] typesNames);

        ITypeDefinitionFilterSequence HaveParameterlessConstructor();
        ITypeDefinitionFilterSequence DoNotHaveParameterlessConstructor();

        //        ITypesFilterPostConditions AreOfType(params System.Type[] types);
        //        ITypesFilterPostConditions AreOfType<T>();
    }
}
