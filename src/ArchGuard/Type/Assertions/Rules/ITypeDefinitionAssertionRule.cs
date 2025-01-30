namespace ArchGuard
{
    public partial interface ITypeDefinitionAssertionRule
    {
        ITypeDefinitionAssertionSequence ImplementInterface(params System.Type[] types);
        ITypeDefinitionAssertionSequence ImplementInterface<T>();

        ITypeDefinitionAssertionSequence NotImplementInterface(params System.Type[] types);
        ITypeDefinitionAssertionSequence NotImplementInterface<T>();

        ITypeDefinitionAssertionSequence Inherit(params System.Type[] type);
        ITypeDefinitionAssertionSequence Inherit<T>();

        ITypeDefinitionAssertionSequence NotInherit(params System.Type[] types);
        ITypeDefinitionAssertionSequence NotInherit<T>();

        ITypeDefinitionAssertionSequence BeGeneric();
        ITypeDefinitionAssertionSequence NotBeGeneric();

        ITypeDefinitionAssertionSequence BeImmutable();
        ITypeDefinitionAssertionSequence BeMutable();

        ITypeDefinitionAssertionSequence BeStateless();
        ITypeDefinitionAssertionSequence NotBeStateless();

        ITypeDefinitionAssertionSequence BeStaticless();
        ITypeDefinitionAssertionSequence NotBeStaticless();

        ITypeDefinitionAssertionSequence BeExternallyImmutable();
        ITypeDefinitionAssertionSequence BeExternallyMutable();

        ITypeDefinitionAssertionSequence HaveDependencyOn(params string[] typesNames);
        ITypeDefinitionAssertionSequence NotHaveDependencyOn(params string[] typesNames);

        ITypeDefinitionAssertionSequence BeUsedBy(params string[] typesNames);
        ITypeDefinitionAssertionSequence NotBeUsedBy(params string[] typesNames);

        ITypeDefinitionAssertionSequence HaveParameterlessConstructor();
        ITypeDefinitionAssertionSequence NotHaveParameterlessConstructor();
    }
}
