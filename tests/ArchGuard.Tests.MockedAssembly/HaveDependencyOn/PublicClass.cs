namespace ArchGuard.Tests.MockedAssembly.HaveDependencyOn
{
    public class PublicClass
    {
        public static void Method() { }
    }

    public static class PublicClassExternalStaticConstructor
    {
        public static PublicClass CreatePublicClass()
        {
            return new PublicClass();
        }
    }
}
