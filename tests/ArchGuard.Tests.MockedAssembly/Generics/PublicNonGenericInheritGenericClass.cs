namespace ArchGuard.Tests.MockedAssembly.Generics
{
    public class PublicNonGenericInheritGenericClass
        : PublicParentNonGenericInheritGenericClass<string>;

    public class PublicParentNonGenericInheritGenericClass<T>;
}
