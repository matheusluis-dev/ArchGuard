namespace ArchGuard.Tests.MockedAssembly.ImplementInterface
{
    public class PublicImplementPublicInterfaceByInheritanceClass
        : PublicParentImplementPublicInterfaceByInheritanceClass;

    public class PublicParentImplementPublicInterfaceByInheritanceClass : IPublicInterface;
}
