namespace ArchGuard.Tests.MockedAssembly.ExternalMutability
{
    public class PublicExternalImmutableWithPublicPropertyPrivateSetClass
    {
        public string String { get; private set; }

        public PublicExternalImmutableWithPublicPropertyPrivateSetClass(string @string)
        {
            String = @string;
        }
    }
}
