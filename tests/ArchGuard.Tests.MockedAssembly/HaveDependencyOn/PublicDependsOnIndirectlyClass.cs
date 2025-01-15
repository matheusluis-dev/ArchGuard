namespace ArchGuard.Tests.MockedAssembly.HaveDependencyOn
{
    public class PublicDependsOnIndirectlyClass
    {
        public PublicDependsOnDirectlyClass PublicDependsOnDirectlyClass { get; set; }
    }

    public class PublicDependsOnDirectlyClass
    {
        public PublicClass PublicClass { get; set; }
    }
}
