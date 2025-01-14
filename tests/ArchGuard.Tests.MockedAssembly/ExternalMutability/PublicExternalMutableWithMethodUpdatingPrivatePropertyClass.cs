namespace ArchGuard.Tests.MockedAssembly.ExternalMutability
{
    public class PublicExternalMutableWithMethodUpdatingPrivatePropertyClass
    {
        private string String { get; set; }

        public PublicExternalMutableWithMethodUpdatingPrivatePropertyClass(string @string)
        {
            SetString(@string);
        }

        public void SetString(string @string)
        {
            String = @string;
        }
    }
}
