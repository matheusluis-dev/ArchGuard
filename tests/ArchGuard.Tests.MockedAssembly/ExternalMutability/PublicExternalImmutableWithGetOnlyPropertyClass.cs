namespace ArchGuard.Tests.MockedAssembly.ExternalMutability
{
    public class PublicExternalImmutableWithGetOnlyPropertyClass
    {
        public string String { get; }

        public PublicExternalImmutableWithGetOnlyPropertyClass(string @string)
        {
            String = @string;
        }
    }
}
