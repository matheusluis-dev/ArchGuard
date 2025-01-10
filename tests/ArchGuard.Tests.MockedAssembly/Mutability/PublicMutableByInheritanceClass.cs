namespace ArchGuard.Tests.MockedAssembly.Mutability
{
    public class PublicMutableByInheritanceClass : PublicMutableParentClass;

    public class PublicMutableParentClass
    {
        public string String { get; set; }
    }
}
