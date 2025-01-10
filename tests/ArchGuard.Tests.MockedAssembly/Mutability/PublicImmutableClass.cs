namespace ArchGuard.Tests.MockedAssembly.Mutability
{
    public class PublicImmutableClass
    {
        public string String { get; }

        public PublicImmutableClass()
        {
            String = nameof(String);
        }
    }
}
