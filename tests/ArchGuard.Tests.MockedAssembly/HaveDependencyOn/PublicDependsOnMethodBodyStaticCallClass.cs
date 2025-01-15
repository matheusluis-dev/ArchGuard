namespace ArchGuard.Tests.MockedAssembly.HaveDependencyOn
{
    public class PublicDependsOnMethodBodyStaticCallClass
    {
        public void Method()
        {
            PublicClass.Method();
        }
    }
}
