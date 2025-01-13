namespace ArchGuard.Tests.MockedAssembly.Inherit
{
    public interface IPublicInheritIPublicInterfaceByInheritanceInterface
        : IPublicParentInheritIPublicInterfaceByInheritanceInterface;

    public interface IPublicParentInheritIPublicInterfaceByInheritanceInterface : IPublicInterface;
}
