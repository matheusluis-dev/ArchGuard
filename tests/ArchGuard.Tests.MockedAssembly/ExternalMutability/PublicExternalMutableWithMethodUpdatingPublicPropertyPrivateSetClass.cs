namespace ArchGuard.Tests.MockedAssembly.ExternalMutability
{
    public class PublicExternalMutableWithMethodUpdatingPublicPropertyPrivateSetClass
    {
        public string String { get; private set; }

        public PublicExternalMutableWithMethodUpdatingPublicPropertyPrivateSetClass(string @string)
        {
            SetString(@string);
        }

        public void SetString(string @string)
        {
            String = @string;
        }
    }
}
