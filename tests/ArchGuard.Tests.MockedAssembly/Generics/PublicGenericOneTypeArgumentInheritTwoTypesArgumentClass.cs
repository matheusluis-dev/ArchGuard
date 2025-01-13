namespace ArchGuard.Tests.MockedAssembly.Generics
{
    public class PublicGenericOneTypeArgumentInheritTwoTypesArgumentClass<T1>
        : PublicParentGenericOneTypeArgumentInheritTwoTypesArgumentClass<T1, string>;

    public class PublicParentGenericOneTypeArgumentInheritTwoTypesArgumentClass<T1, T2>;
}
