namespace ArchGuard.Tests.MockedAssembly.ExternalMutability
{
    public class PublicExternalImmutableWithInitPropertyClass
    {
        public string String { get; init; }

        public PublicExternalImmutableWithInitPropertyClass(string @string)
        {
            String = @string;
        }
    }
}
