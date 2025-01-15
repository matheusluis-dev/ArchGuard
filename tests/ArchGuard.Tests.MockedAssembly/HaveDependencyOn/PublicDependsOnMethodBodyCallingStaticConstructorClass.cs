namespace ArchGuard.Tests.MockedAssembly.HaveDependencyOn
{
    public class PublicDependsOnMethodBodyCallingStaticConstructorClass
    {
        public void Method()
        {
            PublicClassExternalStaticConstructor.CreatePublicClass();
        }
    }
}
