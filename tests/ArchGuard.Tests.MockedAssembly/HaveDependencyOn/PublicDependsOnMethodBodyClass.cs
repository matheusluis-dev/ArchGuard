namespace ArchGuard.Tests.MockedAssembly.HaveDependencyOn
{
    public class PublicDependsOnMethodBodyClass
    {
        public void Method()
        {
            var publicClass = new PublicClass();
        }
    }
}
