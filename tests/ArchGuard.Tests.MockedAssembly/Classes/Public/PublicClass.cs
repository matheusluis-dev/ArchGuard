namespace ArchGuard.Tests.MockedAssembly.Classes.Public
{
    using ArchGuard.Tests.MockedAssembly.Interfaces.Public;

    public class PublicClass : PublicAbstractClass, IPublicInterface
    {
        public int MyProperty { get; set; }
    }
}
