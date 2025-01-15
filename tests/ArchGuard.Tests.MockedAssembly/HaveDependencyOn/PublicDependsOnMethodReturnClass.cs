namespace ArchGuard.Tests.MockedAssembly.HaveDependencyOn
{
    public class PublicDependsOnMethodReturnClass
    {
        public PublicClass GetPublicClass()
        {
            return new PublicClass();
        }
    }
}
