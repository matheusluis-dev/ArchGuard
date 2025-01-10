namespace ArchGuard.Tests.MockedAssembly.Mutability
{
    public class PublicImmutableWithInheritanceClass : PublicImmutableParentClass;

    public class PublicImmutableParentClass
    {
        public string String { get; init; }
    }
}
