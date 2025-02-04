namespace ArchGuard
{
    public partial interface ITypeAssertionRule
    {
        ITypeAssertionSequence ImplementInterface(params Type[] types);
        ITypeAssertionSequence ImplementInterface<T>();

        ITypeAssertionSequence NotImplementInterface(params Type[] types);
        ITypeAssertionSequence NotImplementInterface<T>();

        ITypeAssertionSequence Inherit(params Type[] type);
        ITypeAssertionSequence Inherit<T>();

        ITypeAssertionSequence NotInherit(params Type[] types);
        ITypeAssertionSequence NotInherit<T>();

        ITypeAssertionSequence BeGeneric();
        ITypeAssertionSequence NotBeGeneric();

        ITypeAssertionSequence BeImmutable();
        ITypeAssertionSequence BeMutable();

        ITypeAssertionSequence BeStateless();
        ITypeAssertionSequence NotBeStateless();

        ITypeAssertionSequence BeStaticless();
        ITypeAssertionSequence NotBeStaticless();

        ITypeAssertionSequence BeExternallyImmutable();
        ITypeAssertionSequence BeExternallyMutable();

        ITypeAssertionSequence HaveDependencyOn(params string[] typesNames);
        ITypeAssertionSequence NotHaveDependencyOn(params string[] typesNames);

        ITypeAssertionSequence HaveDependencyOnNamespace(params string[] namespaces);
        ITypeAssertionSequence NotHaveDependencyOnNamespace(params string[] namespaces);

        ITypeAssertionSequence HaveDependencyOnlyOnNamespace(params string[] namespaces);

        ITypeAssertionSequence BeUsedBy(params string[] typesNames);
        ITypeAssertionSequence NotBeUsedBy(params string[] typesNames);

        ITypeAssertionSequence HaveParameterlessConstructor();
        ITypeAssertionSequence NotHaveParameterlessConstructor();

        ITypeAssertionSequence HaveSourceFilePathMatchingNamespace();
    }
}
