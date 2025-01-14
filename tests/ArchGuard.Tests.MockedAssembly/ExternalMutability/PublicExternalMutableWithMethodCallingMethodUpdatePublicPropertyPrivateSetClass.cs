namespace ArchGuard.Tests.MockedAssembly.ExternalMutability
{
    public class PublicExternalMutableWithMethodCallingMethodUpdatePublicPropertyPrivateSetClass
    {
        public string String { get; private set; }

        public PublicExternalMutableWithMethodCallingMethodUpdatePublicPropertyPrivateSetClass(
            string @string
        )
        {
            SetString(@string);
        }

        private void SetString(string @string)
        {
            String = @string;
        }

        public void PublicSetString(string @string)
        {
            SetString(@string);
        }
    }
}
