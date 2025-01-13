namespace ArchGuard.Tests.MockedAssembly.ImplementInterface
{
    public class PublicImplementPublicInterface1ByInheritanceClass
        : PublicParentImplementPublicInterface1ByInheritanceClass;

    public class PublicParentImplementPublicInterface1ByInheritanceClass : IPublicInterface1;
}
